using System.Collections.Generic;
using UnityEngine;

namespace AlreadyGone.DesignPattern.Commands
{
    public abstract class CommandHandler : MonoBehaviour
    {
        private readonly List<Command> _commandList = new();
        private int _currentCommandIndex = 0;

        public void Undo()
        {
            if (_currentCommandIndex > 0)
            {
                _currentCommandIndex--;
                Command command = _commandList[_currentCommandIndex];
                command.UnExecute();
            }
        }

        public void Redo()
        {
            if (_currentCommandIndex < _commandList.Count)
            {
                Command command = _commandList[_currentCommandIndex];
                _currentCommandIndex++;
                command.Execute();
            }
        }

        protected void ExecuteCommand(Command command)
        {
            command.Execute();
            _commandList.Add(command);
            _currentCommandIndex++;
        }
    }
}