﻿using ISIS.Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Ncqrs.Commanding.ServiceModel;

namespace ISIS.Commands.Mapping
{

    public class TermMapping : IMapping
    {
        private readonly CommandService _commandService;

        public TermMapping(CommandService commandService)
        {
            _commandService = commandService;
        }

        public void Register()
        {

            Map.Command<CreateTerm>()
                .ToAggregateRoot<Term>()
                .CreateNew(cmd => new Term(cmd.TermId, cmd.Abbreviation, cmd.Name, cmd.Start, cmd.End))
                .RegisterWith(_commandService);

            Map.Command<RenameTerm>()
                .ToAggregateRoot<Term>()
                .WithId(cmd => cmd.TermId)
                .ToCallOn((cmd, term) => term.Rename(cmd.NewName))
                .RegisterWith(_commandService);

        }
    }


}
