﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.DAL.Models
{
    public class BaseEntity : IBaseEntity, ICloneable
    {
        #region Public and private fields and properties

        public virtual PrimaryColumnEntity PrimaryColumn { get; set; } = new PrimaryColumnEntity(ColumnName.Default);
        public virtual long Id { get => PrimaryColumn.Id; set { PrimaryColumn.Id = value; } }
        public virtual Guid Uid { get => PrimaryColumn.Uid; set { PrimaryColumn.Uid = value; } }

        #endregion

        #region Public and private methods

        public virtual bool EqualsEmpty() => PrimaryColumn == null;

        public virtual byte[] CloneBytes(byte[] bytes)
        {
            byte[] result = new byte[bytes.Length];
            bytes.CopyTo(result, 0);
            return result;
        }

        public virtual string GetBytesLength(byte[] bytes)
        {
            if (bytes == null)
                return $"{LocalizationCore.Strings.Main.DataSizeVolume}: 0 {LocalizationCore.Strings.Main.DataSizeBytes}";
            if (Encoding.Default.GetString(bytes).Length > 1024 * 1024)
                return $"{LocalizationCore.Strings.Main.DataSizeVolume}: {(float)Encoding.Default.GetString(bytes).Length / 1024 / 1024:### ###.###} {LocalizationCore.Strings.Main.DataSizeMBytes}";
            if (Encoding.Default.GetString(bytes).Length > 1024)
                return $"{LocalizationCore.Strings.Main.DataSizeVolume}: {(float)Encoding.Default.GetString(bytes).Length / 1024:### ###.###} {LocalizationCore.Strings.Main.DataSizeKBytes}";
            return $"{LocalizationCore.Strings.Main.DataSizeVolume}: {Encoding.Default.GetString(bytes).Length:### ###} {LocalizationCore.Strings.Main.DataSizeBytes}";
        }

        public virtual string GetStringLength(string str)
        {
            if (string.IsNullOrEmpty(str))
                return $"{LocalizationCore.Strings.Main.DataSizeLength}: 0 {LocalizationCore.Strings.Main.DataSizeChars}";
            return $"{LocalizationCore.Strings.Main.DataSizeLength}: {str.Length:### ###} {LocalizationCore.Strings.Main.DataSizeChars}";
        }

        public virtual object? GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);
            return null;
        }

        public virtual async Task<byte[]> GetBytes(Stream stream, bool useBase64)
        {
            MemoryStream memoryStream = new();
            await stream.CopyToAsync(memoryStream);

            if (useBase64)
            {
                string base64String = Convert.ToBase64String(memoryStream.ToArray(), Base64FormattingOptions.None);
                return Encoding.Default.GetBytes(base64String);
            }
            return memoryStream.ToArray();
        }

        public virtual Image GetImage(byte[] bytes, bool useBase64)
        {

            MemoryStream ms = new(bytes, 0, bytes.Length);
            ms.Write(useBase64 ? Convert.FromBase64String(bytes.ToString()) : bytes, 0, bytes.Length);
            return Image.FromStream(ms, true);
        }

        #endregion

        #region Public and private methods - override

        public override string ToString() => PrimaryColumn == null ? "NULL" : PrimaryColumn.ToString();

        public override int GetHashCode() => PrimaryColumn == null ? -1 : PrimaryColumn.GetHashCode();

        public virtual bool Equals(BaseEntity entity)
        {
            if (entity is null) return false;
            if (ReferenceEquals(this, entity)) return true;
            return PrimaryColumn != null && PrimaryColumn.Equals(entity.PrimaryColumn);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((BaseEntity)obj);
        }

        public virtual bool EqualsDefault() => PrimaryColumn == null || PrimaryColumn.EqualsDefault();

        public virtual object Clone() => PrimaryColumn == null ? new object() : PrimaryColumn.Clone();

        #endregion
    }
}