﻿// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Duende.IdentityServer.Models;

namespace GeekShooping.IdentityServer.MainModule.Home;

public class ErrorViewModel
{
    public ErrorViewModel()
    {
    }

    public ErrorViewModel(string error)
    {
        Error = new ErrorMessage { Error = error };
    }

    public ErrorMessage Error { get; set; }
}
