using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilsNS;

namespace UI.Cli
{
    public class Menu
    {
        static Dictionary<int, Menu> instancias = new Dictionary<int, Menu>();

        private int id;

        private IList<MenuOpcao> Opcoes = null;

        public string Descricao { get; set; }

        /// <summary>
        /// Construtor de Menu Privado
        /// </summary>
        /// <param name="_id"></param>
        private Menu(int _id)
        {
            id = _id;
            Opcoes = new List<MenuOpcao>();
        }

        /// <summary>
        /// Singleton Construtor
        /// </summary>
        /// <param name="_id">Id do Menu</param>
        /// <returns>Menu com o id</returns>
        public static Menu getInstance(int _id = 0)
        {
            if (!instancias.ContainsKey(_id))
            {
                instancias.Add(_id, new Menu(_id));
            }
            return (instancias[_id] as Menu);
        }

        /// <summary>
        /// Adiciona uma opção ao menu
        /// </summary>
        /// <param name="_txtopcao">Texto da opção</param>
        /// <param name="callback">Função de callback</param>
        /// <returns></returns>
        public Menu Add(string _txtopcao, Action callback = null)
        {
            return Add(new MenuOpcao(_txtopcao, callback));
        }

        /// <summary>
        /// Adiciona uma opção ao menu
        /// </summary>
        /// <param name="_opcao">Objecto MenuOpcao</param>
        /// <returns></returns>
        public Menu Add(MenuOpcao _opcao)
        {
            Opcoes.Add(_opcao);
            return this;
        }

        /// <summary>
        /// Rende o Menu
        /// </summary>
        /// <returns>Valor lido do menu</returns>
        public int RendeMenu()
        {
            MostraMenu();
            return LeOpcaoMenu();
        }

        /// <summary>
        /// Mostra o Menu
        /// </summary>
        public void MostraMenu()
        {
            if (Descricao != "")
                Output.MostraLinha($"Menu: {Descricao}");
            for (int i = 0; i < Opcoes.Count; i++)
            {
                Output.MostraLinha($"{i+1}. {Opcoes[i].Nome}");
            }
        }

        /// <summary>
        /// Lê opções do menu
        /// </summary>
        /// <returns></returns>
        public int LeOpcaoMenu()
        {
            int escolha = Input.LeInt("Escolhe uma opção:", 1, Opcoes.Count);
            if (Opcoes[escolha - 1].Callback != null)
                Opcoes[escolha - 1].Callback.Invoke();
            return escolha;
        }
    }
}
