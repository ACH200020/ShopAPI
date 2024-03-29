﻿using Common.Domain.Exceptions;
using Common.Domian.Utils;

namespace Common.Domian.ValueObjects;

public class PhoneNumber : ValueObject
{
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length is < 11 or > 11)
            throw new InvalidDomainDataException("شماره تلفن نامعتبر است");
        Value = value;
    }

    public string Value { get; private set; }
}