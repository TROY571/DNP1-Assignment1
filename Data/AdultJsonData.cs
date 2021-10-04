using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

namespace Assignment1two.Data
{
    public class AdultJsonData:IAdultData
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;

        public AdultJsonData()
        {
            if (!File.Exists(adultFile))
            {
                Seed();
                WriteAdultsToFile();
            }
            else
            {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }
        
        private void Seed()
        {
            Adult[] ad =
            {
                new Adult
                {
                    Id = 1,
                    FirstName = "Siyu",
                    LastName = "Xia",
                    HairColor = "Black",
                    EyeColor = "Brown",
                    Age = 21,
                    Weight = 66,
                    Height = 173,
                    Sex = "M",
                    JobTitle = "Student",
                    Salary = 100
                },

                new Adult
                {
                    Id = 2,
                    FirstName = "Baby",
                    LastName = "Girl",
                    HairColor = "Black",
                    EyeColor = "Brown",
                    Age = 1,
                    Weight = 2,
                    Height = 33,
                    Sex = "F",
                    JobTitle = null,
                    Salary = 0
                },
            };
            adults = ad.ToList();
        }

        public IList<Adult> getAdults()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }

        public void AddAdult(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteAdultsToFile();
        }

        public void RemoveAdult(int adultId)
        {
            Adult toRemove = adults.First(t => t.Id == adultId);
            adults.Remove(toRemove);
            WriteAdultsToFile();
        }

        private void WriteAdultsToFile()
        {
            string adultAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile,adultAsJson);
        }

        public void Update(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.Age = adult.Age;
            toUpdate.Weight = adult.Weight;
            toUpdate.Height = adult.Height;
            toUpdate.Sex = adult.Sex;
            toUpdate.JobTitle = adult.JobTitle;
            toUpdate.Salary = adult.Salary;
            WriteAdultsToFile();
        }

        public Adult Get(int id)
        {
            return adults.FirstOrDefault(t => t.Id == id);
        }
    }
}