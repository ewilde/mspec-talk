using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using Moq;
using NUnit.Framework;
using It = Machine.Specifications.It;

namespace mspec_examples
{
    [TestFixture]
    public class EmplyeeTests
    {
        [Test]
        public void when_initializing_the_view_model_it_should_load_employees_from_the_repo()
        {
            // Arrange
            Moq.Mock<IRepository<Employee>> mock = new Mock<IRepository<Employee>>();
            var employeeViewModel = new EmployeeViewModel(mock.Object);

            //Act
            employeeViewModel.Initialize();

            //Assert
            mock.Verify(x=>x.Getll());
        }
    }

    [Subject(typeof(EmployeeViewModel))]
    public class when_initializing_an_employee_view_model
    {
        private static EmployeeViewModel ViewModel;
        private static Mock<IRepository<Employee>>  Repository;
        Establish context = () =>
            {
                Repository = new Mock<IRepository<Employee>>();
                ViewModel = new EmployeeViewModel(Repository.Object);
            };

        Because of = () => ViewModel.Initialize();

        It should_have_call_the_repository_to_retrive_all_employees
            = () => Repository.Verify(x => x.Getll());
    }

   public class Employee
   {
       public string Name { get; set; }
       public double Pay { get; set; }
   }

    public class EmployeeViewModel
    {
        public IRepository<Employee> Repository { get; set; }

        public EmployeeViewModel(IRepository<Employee> repository)
         {
             Repository = repository;
         }

        public void Initialize()
        {
            this.Employees = this.Repository.Getll();
        }

        protected IList<Employee> Employees { get; set; }
    }

    public interface IRepository<T>
    {
        void Save<T>();
        IList<T> Getll();
    }

    class Repository<T>
    {
         
    }
}
