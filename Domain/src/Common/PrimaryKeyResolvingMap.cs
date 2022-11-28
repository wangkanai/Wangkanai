﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System.Collections.Generic;

namespace Wangkanai.Domain.Common;

public class PrimaryKeyResolvingMap
{
    private readonly Dictionary<IEntity, IEntity> _resolvingMap = new Dictionary<IEntity, IEntity>();

    public void AddPair(IEntity transient, IEntity persistent)
    {
        _resolvingMap[transient] = persistent;
    }

    public void ResolvePrimaryKeys()
    {
        foreach (var pair in _resolvingMap)
        {
            if (pair.Key.Id == 0 && pair.Value.Id != 0)
            {
                pair.Key.Id = pair.Value.Id;

                if (pair.Key is IAuditable transient && pair.Value is IAuditable presistent)
                {
                    transient.CreatedBy   = presistent.CreatedBy;
                    transient.CreatedDate = presistent.CreatedDate;
                    transient.UpdatedBy   = presistent.UpdatedBy;
                    transient.UpdatedDate = presistent.UpdatedDate;
                }
            }
        }
    }
}