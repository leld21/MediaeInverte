namespace Parte2
{
    class Program
    {

        static void MediaeMaiores(int pos, float[] vetor, float comp, float media)
        {
            if (pos == comp)
            {
                int mqmedia = 0;
                for (int i = 0; i < comp; i++)
                {
                    if (vetor[i] > media)
                    {
                        mqmedia++;
                    }
                }
                Console.WriteLine("Média: " + media);
                Console.WriteLine("Números maiores que a média: " + mqmedia);
            }
            else
            {
                media = media + (vetor[pos] / comp);
                MediaeMaiores(pos + 1, vetor, comp, media);
            }

        }

        static float[] InverteVetor(int pos, float[] vetor, int comp)

        {
            float valor = vetor[comp - pos];
            vetor[comp - pos] = vetor[pos];
            vetor[pos] = valor;
            if (pos == (comp / 2))
            {
                return vetor;
            }
            else
            {
                return InverteVetor(pos + 1, vetor, comp);
            }
        }


        static void Main(string[] args)
        {
            float[] vetor = { 4, 1, 3, 5, 2, 6 };

            int comp = vetor.Length;

            MediaeMaiores(0, vetor, (float)comp, 0);

            float[] vetor2 = InverteVetor(0, vetor, comp - 1);

            for (int i = 0; i < vetor2.Length; i++)
            {
                Console.WriteLine(vetor2[i]);
            }
            Console.ReadLine();
        }
    }
}