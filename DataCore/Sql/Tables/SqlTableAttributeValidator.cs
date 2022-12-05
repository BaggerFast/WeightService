﻿//// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
//// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

//using FluentValidation.Results;

//namespace DataCore.Sql.Tables;

///// <summary>
///// Table validation.
///// </summary>
//public class SqlTableAttributeValidator<T> : AbstractValidator<T> where T : SqlTableAtributesBase, new()
//{
//    /// <summary>
//    /// Constructor.
//    /// </summary>
//    protected SqlTableAttributeValidator(bool isCheckCreateDt = true, bool isCheckChangeDt = true)
//    {
//	    RuleFor(item => item.Identity).SetValidator(new SqlFieldIdentityValidator());
//        if (isCheckCreateDt)
//            RuleFor(item => item.CreateDt)
//                .NotEmpty()
//                .NotNull()
//                .GreaterThanOrEqualTo(new DateTime(2020, 01, 01));
//        if (isCheckChangeDt)
//            RuleFor(item => item.ChangeDt)
//                .NotEmpty()
//                .NotNull()
//                .GreaterThanOrEqualTo(new DateTime(2020, 01, 01));
//    }

//    protected bool PreValidateSubEntity<TItem>(TItem? item, ref ValidationResult result) where TItem : SqlTableBase, new()
//	{
//        if (item is not null)
//        {
//	        ValidationResult validationResult = ValidationUtils.GetValidationResult<TItem>(item);
//	        if (!result.IsValid) return result.IsValid;
//        }
//        return result.IsValid;
//    }
//}