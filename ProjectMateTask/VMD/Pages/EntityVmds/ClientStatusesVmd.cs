﻿using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTask.DAL.Repositories;
using ProjectMateTask.Services.AppInfrastructure.NavigationServices;
using ProjectMateTask.Stores.AppInfrastructure.NavigationStores;

namespace ProjectMateTask.VMD.Pages.EntityVmds;

internal sealed class ClientStatusesVmd : BaseEntityVmd<ClientStatus>
{
    protected override void OnDeleteSubEntityFromCollection(object p) => EditableEntity!.Clients.Remove((Client)p);
    
    protected override void AddSubEntityInCollection(INamedEntity entity)=> EditableEntity!.Clients.Add((Client)entity);
   
    
    public ClientStatusesVmd(
        IRepository<ClientStatus?> entitiesRepository,
        SubEntityNavigationService selectedSubEntityNavigationService,
        SelectedEntityNavigationStore selectedSelectedEntitySelectedNavigationStore ) 
        : base(
            entitiesRepository, 
            selectedSubEntityNavigationService, 
            selectedSelectedEntitySelectedNavigationStore){}
}