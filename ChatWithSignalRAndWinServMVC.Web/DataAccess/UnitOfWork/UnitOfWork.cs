using ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.UnitOfWork
{
    public class UnitOfWork : IBaseUnitOfWork
    {
        private ChatDBContext _dataBase;
        private IChatRepository _chatRepository;
        private IUserRepository _userRepository;
        private IMessageRepository _messageRepository;

        public UnitOfWork(ChatDBContext context)
        {
            _dataBase = context;
        }
        public IChatRepository Chats
        {
            get
            {
                if (_chatRepository == null)
                {
                    _chatRepository = new ChatRepository(_dataBase);
                }
                return _chatRepository;
            }
        }

        public IMessageRepository Messages
        {
            get
            {
                if (_messageRepository == null)
                {
                    _messageRepository = new MessageRepository(_dataBase);
                }
                return _messageRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dataBase);
                }
                return _userRepository;
            }
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataBase.Dispose();
                    _dataBase = null;
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}