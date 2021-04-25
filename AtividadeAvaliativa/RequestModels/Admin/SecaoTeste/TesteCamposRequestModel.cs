using System;
using System.Collections.Generic;

namespace AtividadeAvaliativa.RequestModels.Admin.SecaoTeste
{
    public class TesteCamposRequestModel
    {

        public string TxtCampoTexto { get; set; }
        
        public string TxtCampoData { get; set; }
        
        public string CmbCampoSelect { get; set; }
        
        public string CbxCampoCheckbox { get; set; }
        
        public string CbxCampoCheckboxSemValor { get; set; }
        
        public string RdbCampoRadio { get; set; }
        
        public string TxtCampoTextArea { get; set; }

        public void ValidarEFiltrarComException()
        {
            if (TxtCampoTexto == null)
            {
               throw new Exception("Por Favor informe o Campos Texto");
            }
            else
            {
                TxtCampoTexto = TxtCampoTexto.Replace(".", "").Replace("-", "");
                
            }

            if (TxtCampoData == null)
            {
                throw new Exception("Por Favor informe o Campos Data");
            }

            if (CmbCampoSelect == null)
            {
                throw new Exception("Por Favor informe o Campos Select");
            }

            if (CbxCampoCheckbox == null)
            {
                throw new Exception("Por Favor informe o Campos Checkbox");
            }

            if (RdbCampoRadio == null)
            {
                throw new Exception("Por Favor informe o Campos Radio");
            }

            if (TxtCampoTextArea == null)
            {
                throw new Exception("Por Favor informe o Campos Texto Área");
            }
        }

        public List<string> ValidarEFiltrarComListaDeErros()
        {

            var listaDeErros = new List<string>();

            if (TxtCampoTexto == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Texto");
            }
            else
            {
                TxtCampoTexto = TxtCampoTexto.Replace(".", "").Replace("-", "");
                Console.WriteLine(TxtCampoTexto);
            }

            if (TxtCampoData == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Data");
            }

            if (CmbCampoSelect == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Select");
            }

            if (CbxCampoCheckbox == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Checkbox");
            }

            if (RdbCampoRadio == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Radio");
            }

            if (TxtCampoTextArea == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Texto Área");
            }
            
            return listaDeErros;
        }
        
        
    }
}