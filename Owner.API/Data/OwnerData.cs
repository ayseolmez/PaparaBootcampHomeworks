using System.Collections.Generic;
using System;
using Owner.API.Model;

namespace Owner.API.Data
{
    public class OwnerData
    {
        public List<OwnerModel> GetAllOwner()
        {
            return new List<OwnerModel>
            {
                new OwnerModel
                {
                    Id = 100,
                    FirstName = "Ayşe",
                    LastName = "Ölmez",
                    Date = DateTime.Now,
                    Description = "Software Developer",
                    Type = "Home"
                },
                new OwnerModel
                {
                    Id = 101,
                    FirstName = "Ali",
                    LastName = "Kara",
                    Date = DateTime.Now,
                    Description = "Math Teacher",
                    Type = "Home"
                }
            };
        }
    }
}
