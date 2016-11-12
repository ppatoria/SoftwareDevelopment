using System;
using System.Collections;
using System.Collections.Generic;

class BitwiseOperationsSample
{
    int[] GetInput_NotWorking()
        {         
            int[] integers = new int[2];
            try
            {
                Console.WriteLine("Enter two integers separated by comma");
                string input = Console.ReadLine();
                string[] inputs = input.Split(',');                
                for(int i=inputs.GetLowerBound(0); i<inputs.GetUpperBound(0); i++)
                {
                    if(false == int.TryParse(inputs[i].Trim(), out integers[i]))
                        Console.WriteLine("Error Invalid inputs");
                }
                // for(int i=0; i<inputs.Length; i++)
                // {
                //     if(false == int.TryParse(inputs[i].Trim(), out integers[i]))
                //         Console.WriteLine("Error Invalid inputs");
                // }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return integers;
        }

    IList<int> GetInput_better ()
        {         
            IList<int> integers = new List<int>(2);
            try
            {
                Console.WriteLine("Enter two integers separated by comma");
                string[] inputs = Console.ReadLine().Split(',');               
                Array.ForEach(inputs, input => { 
                        int intVal = int.Parse(input.Trim()); 
                        integers.Add(intVal);
                    });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return integers;
        }

    int[] GetInput () //best
        {   
            try
            {
                Console.WriteLine ("Enter two integers separated by comma");
                string[] input = Console.ReadLine().Split(',');
                var converter  = new Converter<string,int> (str => int.Parse(str.Trim()));             
                return Array.ConvertAll(input, converter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }            
        }

    void AND (int[] operands )
        {                        
            Console.WriteLine ("AND Operator: {0}", operands[0] & operands[1]);
        }

    void OR (int[] operands )
        {                        
            Console.WriteLine ("OR Operator: {0}", operands[0] | operands[1]);
        }

    void XOR (int[] operands )
        {                        
            Console.WriteLine ("XOR Operator: {0}", operands[0] ^ operands[1]);
        }

    void Complement (int[] operands )
        {                        
            Console.WriteLine ("Complement Operator on : {0} {1} {2} {3}", 
                               operands[0], ~operands[0], 
                               operands[1], ~operands[1]);
        }

    public static void Main ()
        {       
            try
            {
                BitwiseOperationsSample bitwise = new BitwiseOperationsSample();
                int[] inputs = bitwise.GetInput();
                Console.WriteLine ("Input: {0} {1}", inputs[0], inputs[1]);
                bitwise.AND (inputs);
                bitwise.OR  (inputs);
                bitwise.XOR (inputs);
                bitwise.Complement (inputs);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
}