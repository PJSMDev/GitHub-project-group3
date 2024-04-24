using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using D00_Utility;

namespace GitHubProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Console Unicode
            Utility.SetUnicodeConsole();
            #endregion

            #region Variables
            int maxGroups = 4;      // # máximo de grupo
            string[] traineeNames = new string[4];
            int[] traineeNumbers = new int[4];
            string continuar;       // usada para continuar/parar a leitura/introdução de dados
            #endregion

            #region Prompts
            for (int groupsEnteredAcc = 1; groupsEnteredAcc <= maxGroups; groupsEnteredAcc++)
            {
                Utility.WriteTitle("GitHub Project Groups");

                Utility.WriteMessage("Número do Grupo: ");
                int groupNumber = int.Parse(Console.ReadLine());

                for (int i = 0; i < 4; i++)
                {
                    Utility.WriteMessage($"Nome do elemento {i + 1}: ");
                    traineeNames[i] = Console.ReadLine();
                    Utility.WriteMessage($"Digite o número de aluno Cegid do elemento {traineeNames[i]}: ");
                    traineeNumbers[i] = int.Parse(Console.ReadLine());
                }

                #region Instance
                Groups group = new Groups(groupNumber, traineeNames, traineeNumbers);
                #endregion

                #region Print
                group.PrintGroups();
                #endregion

                #region Breaking Points
                if (groupsEnteredAcc == maxGroups)
                {
                    Utility.WriteMessage("Número máximo de grupos atingido.", "\n");
                }
                else
                {
                    Utility.WriteMessage("Deseja inserir outro grupo? (S/N): ", "\n");
                    continuar = Console.ReadLine();
                    if (continuar.ToLower() != "s")
                    {
                        group.SuccOp();
                        break;      // Se a resposta não for 'S' ou 's', sai
                    }
                }
                #endregion
            }
            #endregion

            #region Terminate Console
            Utility.TerminateConsole();
            #endregion
        }
    }
}
