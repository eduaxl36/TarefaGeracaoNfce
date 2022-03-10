
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TarefaGeracaoNfce.Dao;
using TarefaGeracaoNfce.Util;
using TarefasNFC2.Util;

namespace TarefaGeracaoNfce.teste
{
    internal class SimulacaoSourceMichel
    {
        
        public static bool chamaMetodoSefaz = true;

        static Random numAleatorio = new Random();

        public static int chamaMetodoGeraNota = numAleatorio.Next();

        public static int obterListaBaseDeDados = 5;



        public static List<PedidoNfce> obterPedidosdoBanco() {

            List<PedidoNfce> lst = new List<PedidoNfce>();
            using (StreamReader bf = new StreamReader("../../teste/bancofake.csv"))
            {
                
                string linha = bf.ReadLine();

                while (linha != null) {


                    string[] valores = linha.ToString().Split(';');


                    lst.Add(




                         new PedidoNfce(



                        valores[0],
                        Convert.ToInt32(valores[1]),
                        ConversoresUTeis.converterDataHoraStringEmObjetoTempo(valores[2]),
                        ConversoresUTeis.converterDataHoraStringEmObjetoTempo(valores[3]),
                        ConversoresUTeis.converterDataHoraStringEmObjetoTempo(valores[4]),
                        valores[5],
                        Convert.ToBoolean(valores[6]),
                        Convert.ToBoolean(valores[7])




                        )





                        );


                    linha = bf.ReadLine();
                
                }

 



            }

            return lst;
        }





        public static void gravar(PedidoNfce dados) {

            
            using (StreamWriter sr = new StreamWriter("../../teste/bancofake.csv", true, System.Text.Encoding.UTF8)) {

                sr.WriteLine(dados.ID+";"+dados.Numero+";"+dados.DataEntradaPedido+";"+dados.DataPedido+";"+dados.DataAgendadaParaGeracaoNota+";"+dados.Nota+";"+dados.NotaGerada+";"+dados.NotaAutorizadaSefaz);
            
            }
        
        
        }


        public static void atualizar(PedidoNfce dados)
        {

       

        }



        public static void deletar(PedidoNfce dados)
        {


            using (StreamWriter sr = new StreamWriter("../../teste/bancofake.csv", true, System.Text.Encoding.UTF8))
            {

                sr.WriteLine(dados.ID + ";" + dados.Numero + ";" + dados.DataEntradaPedido + ";" + dados.DataPedido + ";" + dados.DataAgendadaParaGeracaoNota + ";" + dados.Nota + ";" + dados.NotaGerada + ";" + dados.NotaAutorizadaSefaz);

            }


        }



        public static List<PedidoNfce> obterListaTipoNull()
        {

            List<PedidoNfce> lista1 = new List<PedidoNfce>();

            return lista1;


        }




















        public static List<PedidoNfce> obterListaTipo1() {
            DateTime s = DateTime.Now;

         List<PedidoNfce> lista1 = new List<PedidoNfce>();

            lista1.Add(

                new PedidoNfce
                (

                    "899882",
                    2345,
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    default(DateTime),
                    "Nota não gerada",
                    false,
                    false
                 )
              
                
                );


            lista1.Add(

                new PedidoNfce
                (

                    "899883",
                    2346,
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    default(DateTime),
                    "Nota não gerada",
                    false,
                    false
                 )


                );

            lista1.Add(

                new PedidoNfce
                (

                    "899884",
                    2347,
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    default(DateTime),
                    "Nota não gerada",
                    false,
                    false
                 )


                );





            lista1.Add(

                new PedidoNfce
                (

                    "899888",
                    2367,
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    default(DateTime),
                    "Nota não gerada",
                    false,
                    false
                 )


                );





            lista1.Add(

    new PedidoNfce
    (

        "899108765",
        834557,
        ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
        ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
        default(DateTime),
        "Nota não gerada",
        false,
        false
     )


    );



            lista1.Add(

                new PedidoNfce
                (

                    "8998826778",
                    998345,
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    default(DateTime),
                    "Nota não gerada",
                    false,
                    false
                 )


                );


            lista1.Add(

                new PedidoNfce
                (

                    "8998887",
                    2347766,
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    default(DateTime),
                    "Nota não gerada",
                    false,
                    false
                 )


                );

            lista1.Add(

                new PedidoNfce
                (

                    "8998lk84",
                    23433457,
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    default(DateTime),
                    "Nota não gerada",
                    false,
                    false
                 )


                );





            lista1.Add(

                new PedidoNfce
                (

                    "899898888",
                    7654321,
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
                    default(DateTime),
                    "Nota não gerada",
                    false,
                    false
                 )


                );





            lista1.Add(

    new PedidoNfce
    (

        "8991mmmm000",
        8432357,
        ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
        ConversoresUTeis.converterDataStringEmObjetoTempo("2022-05-03"),
        default(DateTime),
        "Nota não gerada",
        false,
        false
     )


    );
            return lista1;


    }


   

    }
}
