using System;
using System.IO;

namespace trab{

    class trab{

        public static void Main(String [] args){

            string [] nomes = new string[4];
            
            int [,] matriz_venda = new int [30,5];
            int[] valor_produto = new int[4];
            int produto =1, dia, quantidade,opcao =10;
            int[] venda_total = new int[4];
           


            while(opcao!=6){                                                               // tabela para escolher a opção.                                                                                                          
                Console.WriteLine("1 - Importar arquivo de produtos\n2 - Registrar venda\n3 – Relatório de vendas\n4 – Relatório de estoque\n5 – Criar arquivo de vendas\n6 - Sair");
                opcao = int.Parse(Console.ReadLine());                                     // foi usado while para manter a tabela até escolher uma opção valida e switch para direcionar a opção escolhida. 

                switch(opcao){
                    case 1:

                   nomes = Nome_produto();                          //chamando os metodo
                   valor_produto = Quantidade_produtos();
                   
                    break;

                    case 2: 
                    
                     while(opcao!=0){
                    
                        Console.WriteLine("informe o produto\n0- "+nomes[0]+"\n1- "+nomes[1]+"\n2- "+nomes[2]+"\n3- "+nomes[3]);
                        produto = int.Parse(Console.ReadLine());
                        if(produto<0||produto>4){
                            Console.WriteLine("venda não computada");
                        }
                        else {

                        Console.WriteLine("informe o dia em que o produto foi vendido");
                        dia = int.Parse(Console.ReadLine());


                        if(dia<1||dia>31){
                            Console.WriteLine("venda não computada");
                        }
                        else{
                        Console.WriteLine("informe a quantidade vendida");
                        quantidade = int.Parse(Console.ReadLine());

                        if(valor_produto[produto]<quantidade) {
                     Console.WriteLine("quantidade do produto menor do que a venda");
                     

                       
                    }
                    
                        else{
                            valor_produto[produto] = Armazena_venda(quantidade,produto,valor_produto);    //enviando o valor para um metodo, para substituir o valor anterior
                             
                             matriz_venda[dia-1,produto+1] = matriz_venda[dia-1,produto+1]+quantidade;  //somando a quantidade vendida na matriz


                            

                             venda_total[produto] = venda_total[produto] + quantidade;      //calculando a venda total
                             

                        }
                    
                    
                    }}
                        Console.WriteLine("deseja continuar?\nprecione qualquer número para Sim e 0 para Não.");
                    opcao = int.Parse(Console.ReadLine());
                    }               

                   

                    break;

                    case 3:    
                   
                   Mostrar_vendas(matriz_venda,nomes);        

                      
                    break;

                    case 4:

                    Mostrar_estoque(valor_produto,nomes);
                    break;

                    case 5:

                        StreamWriter relatorio;

                        string endereco = "C:\\relatorio.txt" ;
                        relatorio = File.CreateText(endereco);
                        for(int i =0;i<nomes.Length;i++){
                            relatorio.WriteLine(nomes[i]+"   :  "+venda_total[i]);          //criando e enviando o valor da venda total para a pasta do programa
                        }
                        relatorio.Close();
                    break;
                }          
         }         
 }

    public static string [] Nome_produto(){             //metodo para receber o nome do produto
        string[] produtos = new string[4];

       
       for(int i=0;i<produtos.Length;i++){
        Console.WriteLine("informe o nome do "+(i+1)+"º produto:");
        produtos[i] = Console.ReadLine();

       }
       
        return produtos;
    }

    public static int [] Quantidade_produtos(){             //metodo para receber a quantidade do produto
        int[] quantidade = new int [4];

            for(int i = 0; i<quantidade.Length;i++){
                Console.WriteLine("informe a quantidade do produto"+(i+1)+"º");
                quantidade[i] = int.Parse(Console.ReadLine());
            }
            return quantidade;
    }


     static int Armazena_venda(int quantidade,int produto,int[] vetor){     //metodo para calcular o valor apos o abate das vendas
        int novo_valor ;

        novo_valor= vetor[produto] - quantidade;

        return novo_valor;
        

     }

        static void Mostrar_vendas(int [,] matriz, string [] nomes){     //metodo para mostrar vendas no mes
            int dia=1;

            Console.WriteLine("                   "+nomes[0]+"              "+nomes[1]+"            "+nomes[2]+"             "+nomes[3]);
             for(  int i = 0; i<30;i++ ) { 
               
 
                Console.WriteLine("\n");
                
                        for(int j = 0;j<5;j++){
                        if(j==0){
                            matriz[i,j]=dia;
                            dia++;
                        }
                        if(j==0){

                            Console.Write("dia  " +matriz[i,j]+"                ");
                            
                        }
                        else{
                            
                            Console.Write(+matriz[i,j]+"                ");
                        } 
                            
                        }
                       
                        
                        
                    }
                     Console.WriteLine("\n");
                    
        }

        static void Mostrar_estoque(int[] quantidade, string[] produto){ //metodo para mostrar o estoque

            for(int i=0;i<produto.Length;i++){
                Console.WriteLine(produto[i]+"   : "+quantidade[i]);
                Console.WriteLine();
            }

        }




        

         

        



        
  
  
  


}
}

    
