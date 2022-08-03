﻿using ProjectMateTask.DAL.Entities.Base;

namespace ProjectMateTask.DAL.Entities.Services;

public static class EntityServices<T> where T : IEntity
{
    public static bool IsCollectionsEqualsNoDeep(ICollection<T> mainCollection, ICollection<T> subCollection)
    {
        if (mainCollection.Count != subCollection.Count) return false;

        if (mainCollection.Count == 0 && subCollection.Count == 0) return true;

        return mainCollection.Count(item => subCollection.All(subItem => subItem.Id != item.Id)) == 0;
        ;
    }
}