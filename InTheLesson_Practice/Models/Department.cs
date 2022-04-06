using InTheLesson_Practice.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    internal class Department:IEnumerable
    {
        private static int _id;
        public List<Employee> _employee;

        public int Id { get; set; }
        public string Name { get; set; }
        

        public Department(string name)
        {
            _id++;
            Id = _id;
            Name = name;
            _employee = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            _employee.Add(employee);
        }

        public Employee GetEmployeeById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("Id null ola bilmez");

            return _employee.Find(x => x.Id == id);
            //throw new NotFoundException("Tapilmadi");
        }

        public void RemoveById(int? id)
        {
            foreach (var item in _employee)
            {
                if (item.Id == id)
                {
                    _employee.Remove(item);
                }
                else if (id == null)
                {
                    throw new NullReferenceException();
                }
            }
            throw new NotFoundException("Tapilmadi!");
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Employee item in _employee)
            {
                yield return item;
            }
        }
    }
}
