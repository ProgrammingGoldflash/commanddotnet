﻿using System;
using System.Collections.Generic;
using CommandDotNet.Tokens;

namespace CommandDotNet.Parsing
{
    internal partial class CommandParser
    {
        private class ParseContext
        {
            private Queue<Token> _tokens;
            private Command _command;

            public CommandContext CommandContext { get; }
            public AppSettings AppSettings => CommandContext.AppConfig.AppSettings;

            public Queue<Token> Tokens
            {
                get => _tokens;
                set => _tokens = value ?? throw new ArgumentNullException(nameof(value));
            }

            public Command Command
            {
                get => _command;
                set
                {
                    _command = value ?? throw new ArgumentNullException(nameof(value));
                    Operands = new OperandQueue(_command.Operands);
                }
            }


            public bool SubcommandsAreAllowed { get; private set; } = true;

            public Option? Option { get; private set; }
            public Token? OptionToken { get; private set; }
            public OperandQueue Operands { get; private set; }

            public bool IgnoreRemainingArguments { get; set; }
            public ICollection<Token> RemainingOperands { get; } = new List<Token>();

            public IParseError? ParserError { get; set; }

            public ParseContext(CommandContext commandContext, Queue<Token> tokens)
            {
                CommandContext = commandContext ?? throw new ArgumentNullException(nameof(commandContext));
                _command = commandContext.RootCommand ?? throw new ArgumentNullException(nameof(commandContext.RootCommand));
                Operands = new OperandQueue(_command.Operands);
                Tokens = _tokens = tokens;
            }

            public void ExpectOption(Option option, Token token)
            {
                Option = option ?? throw new ArgumentNullException(nameof(option));
                OptionToken = token ?? throw new ArgumentNullException(nameof(token));
            }

            public void ClearOption()
            {
                Option = null;
                OptionToken = null;
            }

            public void CommandArgumentParsed() => SubcommandsAreAllowed = false;
        }
    }
}