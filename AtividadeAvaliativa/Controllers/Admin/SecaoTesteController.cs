using System;
using System.Collections.Generic;
using AtividadeAvaliativa.Models.Cliente;
using AtividadeAvaliativa.Models.Teste;
using AtividadeAvaliativa.RequestModels.Admin.SecaoTeste;
using AtividadeAvaliativa.ViewModel.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace AtividadeAvaliativa.Controllers.Admin
{
    [Authorize]
    public class SecaoTesteController : AdminController
    {

        private readonly TesteService _testeService;
        private readonly ClienteService _clienteService;

        public SecaoTesteController(TesteService testeService, ClienteService clienteService)
        {
            _testeService = testeService;
            _clienteService = clienteService;
        }
        
        [HttpGet]
        public IActionResult Index(FiltroListagemClientes request)
        {
            var viewmodel = new IndexViewModel()
            {
                FormMensagemSucesso = (string) TempData["formMensagemSucesso"],
                FormMensagensErro = (string[]) TempData["formMensagensErro"]
            };
            
            //Obter Listagem de Clientes com filtro

            var filtroNome = request.nome;
            var filtroEmail = request.email;
            var filtroApenasComEvento = request.apenasComEvento;

            var clientes = _clienteService.ObterClientesComFiltro(filtroNome, filtroEmail, filtroApenasComEvento);
            
            //Inserir lista de clientes na viewModel

            foreach (var cliente in clientes)
            {
                viewmodel.ListaCliente.Add(new IndexViewModel.Cliente()
                {
                    Id = cliente.Id.ToString(),
                    Nome = cliente.nome,
                    Email = cliente.email,
                    QtdEventos = cliente.Eventos.Count.ToString(),
                });
            }
            
            //Inserir filtros na viewmodel

            viewmodel.Filtro = new IndexViewModel.Filtros()
            {
                Nome = filtroNome,
                Email = filtroEmail,
                ApenasComEventos = filtroApenasComEvento,

            };
            
            return View(NomeDaView(), viewmodel);
        }

        [HttpPost]
        public RedirectToActionResult Index(TesteCamposRequestModel request)
        {

            var text = request.TxtCampoTexto;
            var date = request.TxtCampoData;
            var select = request.CmbCampoSelect;
            var checkbox = request.CbxCampoCheckbox;
            var chechboxsemvalor = request.CbxCampoCheckboxSemValor;
            var radio = request.RdbCampoRadio;
            var textArea = request.TxtCampoTextArea;

            Console.WriteLine("Valor Campo Texto: " + text);
            Console.WriteLine("Valor Campo Date: " + date);
            Console.WriteLine("Valor Campo Select: " + select);
            Console.WriteLine("Valor Campo CheckBox: " + checkbox);
            Console.WriteLine("Valor Campo CheckBox Sem Valor: " + chechboxsemvalor);
            Console.WriteLine("Valor Campo Radio: " + radio);
            Console.WriteLine("Valor Campo Texto Área: " + textArea);

            // --------------------------------------------

            var listaDeErros = new List<string>();

            if (text == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Texto");
            }
            else
            {
                text = text.Replace(".", "").Replace("-", "");
                Console.WriteLine(text);
            }

            if (date == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Data");
            }

            if (select == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Select");
            }

            if (checkbox == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Checkbox");
            }

            if (radio == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Radio");
            }

            if (textArea == null)
            {
                listaDeErros.Add("Por Favor informe o Campos Texto Área");
            }

            if (listaDeErros.Count > 0)
            {
                TempData["formMensagensErro"] = listaDeErros;
                return RedirectToAction("Index");
            }

            //-------------------------------------

            try
            {
                _testeService.RealizaAlgumaOperacao(text);
                TempData["formMensagemSucesso"] = "Operação Realizada com Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["formMensagensErro"] = new List<string> {exception.Message};
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public RedirectToActionResult ProcessarFormulario(TesteCamposRequestModel request)
        {
            try
            {
                request.ValidarEFiltrarComException();
            }
            catch (Exception exception)
            {
                TempData["formMensagensErro"] = new List<string> {exception.Message};
                return RedirectToAction("Index");
            }
            
            try
            {
                _testeService.RealizaAlgumaOperacao(request.TxtCampoTexto);
                TempData["formMensagemSucesso"] = "Operação Realizada com Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["formMensagensErro"] = new List<string> {exception.Message};
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public RedirectToActionResult ProcessarFormularioOutraForma(TesteCamposRequestModel request)
        {
            var listaDeErros = request.ValidarEFiltrarComListaDeErros();
            if (listaDeErros.Count > 0)
            {
                TempData["formMensagensErro"] = listaDeErros;
                return RedirectToAction("Index");
            }

            try
            {
                _testeService.RealizaAlgumaOperacao(request.TxtCampoTexto);
                TempData["formMensagemSucesso"] = "Operação realizada com Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["formMensagensErro"] = new List<string> {exception.Message};
                return RedirectToAction("Index");
            }
        }
        
    }
}