﻿using System;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices.Base.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores.Base;
using ProjectMateTask.VMD.Pages.AdditionalPagesVmds.Base;

namespace ProjectMateTask.Services.AppInfrastructure.NavigationServices;

/// <summary>
///     Сервис навигации по дополнительному окну
/// </summary>
internal sealed  class AdditionalPageStoreNavigationService : BaseStoreNavigationServices<BaseAdditionalVmd>
{
    public AdditionalPageStoreNavigationService(INavigationStore<BaseAdditionalVmd> navigationStore, Func<BaseAdditionalVmd> createVmd) : base(navigationStore, createVmd)
    {
    }
}