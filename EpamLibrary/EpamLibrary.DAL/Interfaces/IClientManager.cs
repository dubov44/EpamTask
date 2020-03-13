using EpamLibrary.DAL.Entities;
using System;
using EpamLibrary.Tables.Models;

namespace EpamLibrary.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
        void Update(ClientProfile item);
        ClientProfile GetById(string id);
    }
}