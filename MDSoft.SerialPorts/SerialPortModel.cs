﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.IO.Ports;
using System.Threading;

namespace MDSoft.SerialPorts
{
    public delegate void SerialPortEventHandler(object sender, SerialPortEventArgs e);

    public class SerialPortModel
    {
        public SerialPort SerialPort { get; private set; } = new();
        public event SerialPortEventHandler ComReceiveDataEvent = null;
        public event SerialPortEventHandler ComOpenEvent = null;
        public event SerialPortEventHandler ComCloseEvent = null;
        private readonly object _locker = new();

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (SerialPort.BytesToRead <= 0)
            {
                return;
            }
            lock (_locker)
            {
                int len = SerialPort.BytesToRead;
                byte[] data = new byte[len];
                try
                {
                    SerialPort.Read(data, 0, len);
                }
                catch (Exception)
                {
                    //
                }
                SerialPortEventArgs args = new()
                {
                    ReceivedBytes = data
                };
                ComReceiveDataEvent?.Invoke(this, args);
            }
        }

        public bool Send(byte[] bytes)
        {
            if (!SerialPort.IsOpen)
            {
                return false;
            }

            try
            {
                SerialPort.Write(bytes, 0, bytes.Length);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void Open(SerialPort serialPort)
        {
            Open(serialPort.PortName, serialPort.BaudRate.ToString(), serialPort.DataBits.ToString(), serialPort.StopBits.ToString(), 
                serialPort.Parity.ToString(), serialPort.Handshake.ToString(), serialPort.ReadTimeout, serialPort.WriteTimeout);
        }

        public void Open(string portName, string baudRate, string dataBits, string stopBits, string parity, string handshake,
            int readTimeout = 1_000, int writeTimeout = 1_000)
        {
            if (SerialPort.IsOpen)
            {
                Close();
                return;
            }

            SerialPort.PortName = portName;
            SerialPort.BaudRate = Convert.ToInt32(baudRate);
            SerialPort.DataBits = Convert.ToInt16(dataBits);

            /**
             *  If the Handshake property is set to None the DTR and RTS pins 
             *  are then freed up for the common use of Power, the PC on which
             *  this is being typed gives +10.99 volts on the DTR pin & +10.99
             *  volts again on the RTS pin if set to true. If set to false 
             *  it gives -9.95 volts on the DTR, -9.94 volts on the RTS. 
             *  These values are between +3 to +25 and -3 to -25 volts this 
             *  give a dead zone to allow for noise immunity.
             *  http://www.codeproject.com/Articles/678025/Serial-Comms-in-Csharp-for-Beginners
             */
            if (handshake == "None")
            {
                // Never delete this property.
                SerialPort.RtsEnable = true;
                SerialPort.DtrEnable = true;
            }

            SerialPortEventArgs args = new();
            try
            {
                SerialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
                SerialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
                SerialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake);
                SerialPort.ReadTimeout = readTimeout;
                SerialPort.WriteTimeout = writeTimeout;
                SerialPort.Open();
                SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
                args.IsOpened = true;
            }
            catch (Exception)
            {
                args.IsOpened = false;
            }
            ComOpenEvent?.Invoke(this, args);
        }

        /**
         *  Take care to avoid deadlock when calling Close on the SerialPort in response to a GUI event.
         *   An app involving the UI and the SerialPort freezes up when closing the SerialPort
         *   Deadlock can occur if Control.Invoke() is used in serial port event handlers
         * 
         *  The typical scenario we encounter is occasional deadlock in an app 
         *  that has a data received handler trying to update the GUI at the 
         *  same time the GUI thread is trying to close the SerialPort (for 
         *  example, in response to the user clicking a Close button).
         * 
         *  The reason deadlock happens is that Close() waits for events to 
         *  finish executing before it closes the port. You can address this 
         *  problem in your apps in two ways:
         * 
         *  (1)In your event handlers, replace every Control.Invoke call with 
         *  Control.BeginInvoke, which executes asynchronously and avoids 
         *  the deadlock condition. This is commonly used for deadlock avoidance 
         *  when working with GUIs.
         *  
         *  (2)Call serialPort.Close() on a separate thread. You may prefer this
         *  because this is less invasive than updating your Invoke calls.
         */
        public void Close()
        {
            Thread closeThread = new(new ThreadStart(CloseThread));
            closeThread.Start();
        }

        private void CloseThread()
        {
            SerialPortEventArgs args = new()
            {
                IsOpened = false
            };
            try
            {
                SerialPort.Close();
                SerialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceived);
            }
            catch (Exception)
            {
                args.IsOpened = true;
            }
            ComCloseEvent?.Invoke(this, args);
        }
    }
}