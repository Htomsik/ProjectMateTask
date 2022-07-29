﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using ProjectMateTask.DAL.Entities;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Repositories;

namespace ProjectMateTask.VMD.Base;

internal abstract class BaseEntityPageVmd<TEntity>:BaseVmd where TEntity:NamedEntity,new()
{
    private readonly IRepository<TEntity> _entitiesRepository;

    #region Оригинльный список

    private ObservableCollection<TEntity> _entities;

    public ObservableCollection<TEntity> Entities
    {
        get => _entities;
        set
        {
            _entitiesViewSource = new CollectionViewSource
            {
                Source = value,
                SortDescriptions =
                {
                    new SortDescription("Name",ListSortDirection.Ascending)
                }
            };

            _entitiesViewSource.Filter += OnEntityFilter;
            _entitiesViewSource.View.Refresh();
            
            OnPropertyChanged(nameof(EntitiesFilteredView));
        }
    }

  

    #endregion
    
    #region фильтация списка

        private string _filter;
        
        public string Filter
        {
            get => _filter;
            set
            {
               if(Set(ref _filter, value))
                   _entitiesViewSource.View.Refresh();
            }
        }

        private void OnEntityFilter(object sender, FilterEventArgs e)
        {
            if(!(e.Item is NamedEntity entity) || string.IsNullOrEmpty(Filter)) return;

            if (!entity.Name.Contains(Filter)) e.Accepted = false;
        }

    #endregion
    
    #region Отфильтрованный список

    private CollectionViewSource _entitiesViewSource;

    public ICollectionView? EntitiesFilteredView => _entitiesViewSource?.View;

    #endregion

    #region Выбранная сущность из списка

    private TEntity _selectedEntity;

    public TEntity SelectedEntity
    {
        get => _selectedEntity;
        set => Set(ref _selectedEntity, value);
    }
    
    #endregion
    
    public BaseEntityPageVmd(IRepository<TEntity> entitiesRepository)
    {
        _entitiesRepository = entitiesRepository;
        
        Entities = new ObservableCollection<TEntity>( _entitiesRepository.Items.ToArray());
    }

}