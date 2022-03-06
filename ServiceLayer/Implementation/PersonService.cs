using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class PersonService : IPerson
    {
        private readonly BDDContext _dbContext;

        public PersonService(BDDContext bddContext)
        {
            this._dbContext = bddContext;
        }
        public String AddPerson(Person pers)
        {
            try
            {
                this._dbContext.Add(pers);
                this._dbContext.SaveChanges();
                return "We add new person";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public List<Person> getPeople()
        {
            return this._dbContext.People.ToList();
        }

        public Person getPersonById(int id)
        {
            Person p= this._dbContext.People.Find(id);
            if (p == null)
                return null;
            return p;
            
        }

        public string RemovePerson(int id)
        {
            try
            {
                var user = this.getPersonById(id);
                this._dbContext.People.Remove(user);
                this._dbContext.SaveChanges();
                return "person removed successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String UpdatePerson(int id,Person pers)
        {
            try
            {
                var peopleUpdate = this._dbContext.People.Find(id);
                if (peopleUpdate != null)
                {
                    peopleUpdate.lastName = pers.lastName;
                    peopleUpdate.firstName = pers.firstName;
                    peopleUpdate.CIN = pers.CIN;
                    peopleUpdate.phone = pers.phone;

                    this._dbContext.People.Update(peopleUpdate);
                    this._dbContext.SaveChanges();
                    return "Person update successfully";
                }
                else
                {
                    return "Aucune personne trouver";
                }

            }
            catch (Exception e){
                return e.Message;
            }
        }
    }
}
