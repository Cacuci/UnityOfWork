using System;
using UnityOfWork.Models;

namespace UnityOfWork
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Unity Of Work");

            var unityOfWork = new UnityOfWork.UnityOfWork();            

            unityOfWork.ClientRepository.Add(new Client());
            unityOfWork.ProductRepository.Add(new Product());

            unityOfWork.Commit();
        }
    }
}
