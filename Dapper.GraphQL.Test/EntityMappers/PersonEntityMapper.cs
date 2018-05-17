﻿using Dapper.GraphQL.Test.Models;
using GraphQL.Language.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.GraphQL.Test.EntityMappers
{
    public class PersonEntityMapper :
        EntityMapper<Person>
    {
        public override Person Map(EntityMapContext<Person> context)
        {
            // NOTE: Order is very important here.  We must map the objects in
            // the same order they were queried in the QueryBuilder.
            var person = context.Start();
            var email = context.Next<Email>("emails");
            var phone = context.Next<Phone>("phones");
            var supervisor = context.Next<Person>("supervisor", this);
            var careerCounselor = context.Next<Person>("careerCounselor", this);

            if (person != null)
            {
                if (email != null &&
                    // Eliminate duplicates
                    !person.Emails.Any(e => e.Address == email.Address))
                {
                    person.Emails.Add(email);
                }

                if (phone != null &&
                    // Eliminate duplicates
                    !person.Phones.Any(p => p.Number == phone.Number))
                {
                    person.Phones.Add(phone);
                }

                person.Supervisor = supervisor;
                person.CareerCounselor = careerCounselor;
            }

            return person;
        }
    }
}