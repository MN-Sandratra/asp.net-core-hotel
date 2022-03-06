using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.Model;

namespace ServiceLayer.Interfaces
{
    public interface IPerson
    {
        //get People
        List<Person> getPeople();

        //get Person by id
        Person getPersonById(int id);

        //Add
        String AddPerson(Person pers);
        //update
        String UpdatePerson(int id,Person pers);
        //delete
        String RemovePerson(int id);

    }
}
