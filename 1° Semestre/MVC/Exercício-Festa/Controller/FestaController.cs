using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Primeiro_Exercício_MVC.Model;
using Primeiro_Exercício_MVC.View;

namespace Primeiro_Exercício_MVC.Controller
{
    public class FestaController
    {
        FestaModel festaModel = new FestaModel();
        FestaView festaView = new FestaView();

        public void ListaIngressos()
        {
            //chmada da model
            List<FestaModel> ingressos = new List<FestaModel>();
        }

        public void CadNoCsv()
        {
            festaModel.Inserir(festaView.Cadastrar());
            Console.WriteLine($"Produto cadastrado com sucesso.");
        }
    }
}