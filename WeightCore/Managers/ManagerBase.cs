﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataProjectsCore;
using DataProjectsCore.DAL;
using DataProjectsCore.Helpers;
using DataShareCore.Models;
using Nito.AsyncEx;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using WeightCore.Helpers;
using static DataShareCore.Models.IDisposableBase;

namespace WeightCore.Managers
{
    public class ManagerBase : DisposableBase, IDisposableBase
    {
        #region Public and private fields and properties - Manager

        public ProjectsEnums.TaskType TaskType { get; set; } = ProjectsEnums.TaskType.Default;
        public ExceptionHelper Exception { get; set; } = ExceptionHelper.Instance;
        public DebugHelper Debug { get; set; } = DebugHelper.Instance;
        public LogHelper Log { get; set; } = LogHelper.Instance;
        public AsyncLock MutexReopen { get; private set; }
        public AsyncLock MutexRequest { get; private set; }
        public AsyncLock MutexResponse { get; private set; }
        public CancellationTokenSource CtsReopen { get; set; }
        public CancellationTokenSource CtsRequest { get; set; }
        public CancellationTokenSource CtsResponse { get; set; }
        public string ProgressString { get; set; }
        public ushort WaitReopen { get; set; }
        public ushort WaitRequest { get; set; }
        public ushort WaitResponse { get; set; }
        public ushort WaitException { get; set; }
        public ushort WaitClose { get; set; }
        public string ExceptionMsg { get; set; }
        public bool IsResponse { get; set; }
        public Task TaskReopen { get; set; } = null;
        public Task TaskRequest { get; set; } = null;
        public Task TaskResponse { get; set; } = null;
        public bool IsOpenedMethod { get; set; }
        public bool IsClosedMethod { get; set; }

        #endregion

        #region Public and private methods

        public ManagerBase() : base()
        {
            Init(CloseMethod, ReleaseManaged, ReleaseUnmanaged);
        }

        public void Init(ProjectsEnums.TaskType taskType, InitCallback initCallback,
            ushort waitReopen = 0, ushort waitRequest = 0, ushort waitResponse = 0, ushort waitClose = 0, ushort waitException = 0)
        {
            lock (this)
            {
                TaskType = taskType;

                WaitReopen = waitReopen == 0 ? (ushort)2_000 : waitReopen;
                WaitRequest = waitRequest == 0 ? (ushort)250 : waitRequest;
                WaitResponse = waitResponse == 0 ? (ushort)500 : waitResponse;
                WaitClose = waitClose == 0 ? (ushort)3_000 : waitClose;
                WaitException = waitException == 0 ? (ushort)2_000 : waitException;

                initCallback?.Invoke();
            }
        }

        public static void WaitSync(ushort miliseconds, Task task = null)
        {
            if (miliseconds < 50)
                miliseconds = 50;
            if (miliseconds > 10_000)
                miliseconds = 10_000;
            Stopwatch sw = Stopwatch.StartNew();
            sw.Restart();
            while (sw.Elapsed.TotalMilliseconds < miliseconds)
            {
                if (task != null && task.Status != TaskStatus.WaitingForActivation)
                    if (task.Status == TaskStatus.Canceled || task.Status == TaskStatus.Faulted)
                        break;
                Thread.Sleep(50);
                System.Windows.Forms.Application.DoEvents();
            }
            sw.Stop();
        }

        public void DebugLog(string message, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
        {
            CheckIsDisposed();
            if (Debug.IsDebug)
                Log.Information(message, filePath, memberName, lineNumber);
        }

        public void Open(SqlViewModelEntity sqlViewModel,
            ReopenCallback reopenCallback, RequestCallback requestCallback, ResponseCallback responseCallback)
        {
            CloseMethod();
            if (IsOpenedMethod) return;
            IsOpenedMethod = true;
            IsClosedMethod = false;
            Open();

            MutexReopen = null;
            MutexRequest = null;
            MutexResponse = null;

            CtsReopen = null;
            CtsRequest = null;
            CtsResponse = null;
            
            if (sqlViewModel.IsTaskEnabled(TaskType))
            {
                OpenTaskReopen(reopenCallback);
                OpenTaskRequest(requestCallback);
                OpenTaskResponse(responseCallback);
            }
        }

        private void OpenTaskBase(Task task, CancellationTokenSource cts)
        {
            CheckIsDisposed();
            if (task == null) return;
            
            cts?.Cancel();
            task.Wait(WaitClose);
            if (task.IsCompleted)
                task.Dispose();
            task = null;
        }

        private void OpenTaskReopen(ReopenCallback callback)
        {
            OpenTaskBase(TaskReopen, CtsReopen);
            CtsReopen = new CancellationTokenSource();

            TaskReopen = Task.Run(async () =>
            {
                MutexReopen = new AsyncLock();
                while (MutexReopen != null && CtsReopen != null)
                {
                    // AsyncLock can be locked asynchronously
                    using (await MutexReopen.LockAsync(CtsReopen.Token))
                    {
                    if (CtsReopen.IsCancellationRequested)
                        break;
                        try
                        {
                            // It's safe to await while the lock is held
                            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(true);
                            callback?.Invoke();
                            WaitSync(WaitReopen);
                        }
                        catch (TaskCanceledException)
                        {
                            // Console.WriteLine(tcex.Message);
                            // Not the problem.
                        }
                        catch (Exception ex)
                        {
                            Exception.Catch(null, ref ex, false);
                            WaitSync(WaitException);
                        }
                    }
                }
            });
        }

        private void OpenTaskRequest(RequestCallback callback)
        {
            OpenTaskBase(TaskRequest, CtsRequest);
            CtsRequest = new CancellationTokenSource();

            TaskRequest = Task.Run(async () =>
            {
                MutexRequest = new AsyncLock();
                while (MutexRequest != null && CtsRequest != null)
                {
                    // AsyncLock can be locked asynchronously
                    using (await MutexRequest.LockAsync(CtsRequest.Token))
                    {
                        if (CtsRequest.IsCancellationRequested)
                            break;
                        try
                        {
                            // It's safe to await while the lock is held
                            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(true);
                            callback?.Invoke();
                            WaitSync(WaitRequest);
                        }
                        catch (TaskCanceledException)
                        {
                            // Console.WriteLine(tcex.Message);
                            // Not the problem.
                        }
                        catch (Exception ex)
                        {
                            Exception.Catch(null, ref ex, false);
                            WaitSync(WaitException);
                        }
                    }
                }
            });
        }

        private void OpenTaskResponse(ResponseCallback callback)
        {
            OpenTaskBase(TaskResponse, CtsResponse);
            CtsResponse = new CancellationTokenSource();

            TaskResponse = Task.Run(async () =>
            {
                MutexResponse = new AsyncLock();
                while (MutexResponse != null && CtsResponse != null)
                {
                    // AsyncLock can be locked asynchronously
                    using (await MutexResponse.LockAsync(CtsResponse.Token))
                    {
                        if (CtsResponse.IsCancellationRequested)
                            break;
                        try
                        {
                            // It's safe to await while the lock is held
                            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(true);
                            callback?.Invoke();
                            WaitSync(WaitResponse);
                        }
                        catch (TaskCanceledException)
                        {
                            // Console.WriteLine(tcex.Message);
                            // Not the problem.
                        }
                        catch (Exception ex)
                        {
                            Exception.Catch(null, ref ex, false);
                            WaitSync(WaitException);
                        }
                    }
                }
            });
        }

        public void CloseMethod()
        {
            if (IsClosedMethod) return;
            IsOpenedMethod = false;
            IsClosedMethod = true;
            CheckIsDisposed();

            CtsReopen?.Cancel();
            CtsRequest?.Cancel();
            CtsResponse?.Cancel();

            WaitSync(WaitClose);
            
            MutexReopen = null;
            MutexRequest = null;
            MutexResponse = null;

            DebugLog($"{nameof(TaskType)} is closed");
        }

        public void ReleaseManaged()
        {
            CloseMethod();

            CtsReopen?.Cancel();
            CtsReopen?.Dispose();
            CtsRequest?.Cancel();
            CtsRequest?.Dispose();
            CtsResponse?.Cancel();
            CtsResponse?.Dispose();
            
            if (TaskReopen != null)
            {
                TaskReopen.Wait(100);
                if (TaskReopen.IsCompleted)
                    TaskReopen.Dispose();
                TaskReopen = null;
            }

            if (TaskRequest != null)
            {
                TaskRequest.Wait(100);
                if (TaskRequest.IsCompleted)
                    TaskRequest.Dispose();
                TaskRequest = null;
            }

            if (TaskResponse != null)
            {
                TaskResponse.Wait(100);
                if (TaskResponse.IsCompleted)
                    TaskResponse.Dispose();
                TaskResponse = null;
            }

            CtsReopen = null;
            CtsRequest = null;
            CtsResponse = null;
        }

        public void ReleaseUnmanaged()
        {
            //
        }

        #endregion
    }
}