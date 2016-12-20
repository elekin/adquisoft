using AI.Fuzzy.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluate
{
    class CostoCalidad
    {
        private double valorCalidadProducto;
        private double valorCostoTotal;

        public CostoCalidad(double valorCalidadProducto, double valorCostoTotal)
        {
            this.valorCalidadProducto = valorCalidadProducto;
            this.valorCostoTotal = valorCostoTotal;
        }

        MamdaniFuzzySystem _fsCostoCalidad = null;

        MamdaniFuzzySystem CrearSistemaCostoCalidad()
        {
            MamdaniFuzzySystem fsCostoCalidad = new MamdaniFuzzySystem();

            FuzzyVariable fvCalidadProducto = new FuzzyVariable("calidad_producto", 0.0, 1.0);
            fvCalidadProducto.Terms.Add(new FuzzyTerm("muy_mala", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
            fvCalidadProducto.Terms.Add(new FuzzyTerm("mala", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
            fvCalidadProducto.Terms.Add(new FuzzyTerm("regular", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
            fvCalidadProducto.Terms.Add(new FuzzyTerm("buena", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
            fvCalidadProducto.Terms.Add(new FuzzyTerm("excelente", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
            fsCostoCalidad.Input.Add(fvCalidadProducto);

            FuzzyVariable fvCostoTotal = new FuzzyVariable("costo_total", 0.0, 1.0);
            fvCostoTotal.Terms.Add(new FuzzyTerm("no_tiene", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
            fvCostoTotal.Terms.Add(new FuzzyTerm("bajo", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
            fvCostoTotal.Terms.Add(new FuzzyTerm("regular", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
            fvCostoTotal.Terms.Add(new FuzzyTerm("alto", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
            fvCostoTotal.Terms.Add(new FuzzyTerm("muy_alto", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
            fsCostoCalidad.Input.Add(fvCostoTotal);



            FuzzyVariable fvPuntajeSoftware = new FuzzyVariable("puntaje_software", 0.0, 1.0);
            fvPuntajeSoftware.Terms.Add(new FuzzyTerm("muy_malo", new TrapezoidMembershipFunction(0.0, 0.0, 0.1, 0.3)));
            fvPuntajeSoftware.Terms.Add(new FuzzyTerm("malo", new TriangularMembershipFunction(0.1, 0.3, 0.5)));
            fvPuntajeSoftware.Terms.Add(new FuzzyTerm("regular", new TriangularMembershipFunction(0.3, 0.5, 0.7)));
            fvPuntajeSoftware.Terms.Add(new FuzzyTerm("bueno", new TriangularMembershipFunction(0.5, 0.7, 0.9)));
            fvPuntajeSoftware.Terms.Add(new FuzzyTerm("excelente", new TrapezoidMembershipFunction(0.7, 0.9, 1.0, 1.0)));
            fsCostoCalidad.Output.Add(fvPuntajeSoftware);

            try
            {
                MamdaniFuzzyRule r0 = fsCostoCalidad.ParseRule("if (calidad_producto is muy_mala) and (costo_total is no_tiene) then puntaje_software is muy_malo");
                MamdaniFuzzyRule r1 = fsCostoCalidad.ParseRule("if (calidad_producto is mala) and (costo_total is no_tiene) then puntaje_software is malo");
                MamdaniFuzzyRule r2 = fsCostoCalidad.ParseRule("if (calidad_producto is regular) and (costo_total is no_tiene) then puntaje_software is regular");
                MamdaniFuzzyRule r3 = fsCostoCalidad.ParseRule("if (calidad_producto is buena) and (costo_total is no_tiene) then puntaje_software is bueno");
                MamdaniFuzzyRule r4 = fsCostoCalidad.ParseRule("if (calidad_producto is excelente) and (costo_total is no_tiene) then puntaje_software is excelente");
                MamdaniFuzzyRule r5 = fsCostoCalidad.ParseRule("if (calidad_producto is muy_mala) and (costo_total is bajo) then puntaje_software is muy_malo");
                MamdaniFuzzyRule r6 = fsCostoCalidad.ParseRule("if (calidad_producto is mala) and (costo_total is bajo) then puntaje_software is malo");
                MamdaniFuzzyRule r7 = fsCostoCalidad.ParseRule("if (calidad_producto is regular) and (costo_total is bajo) then puntaje_software is regular");
                MamdaniFuzzyRule r8 = fsCostoCalidad.ParseRule("if (calidad_producto is buena) and (costo_total is bajo) then puntaje_software is bueno");
                MamdaniFuzzyRule r9 = fsCostoCalidad.ParseRule("if (calidad_producto is excelente) and (costo_total is bajo) then puntaje_software is excelente");
                MamdaniFuzzyRule r10 = fsCostoCalidad.ParseRule("if (calidad_producto is muy_mala) and (costo_total is regular) then puntaje_software is muy_malo");
                MamdaniFuzzyRule r11 = fsCostoCalidad.ParseRule("if (calidad_producto is mala) and (costo_total is regular) then puntaje_software is muy_malo");
                MamdaniFuzzyRule r12 = fsCostoCalidad.ParseRule("if (calidad_producto is regular) and (costo_total is regular) then puntaje_software is regular");
                MamdaniFuzzyRule r13 = fsCostoCalidad.ParseRule("if (calidad_producto is buena) and (costo_total is regular) then puntaje_software is regular");
                MamdaniFuzzyRule r14 = fsCostoCalidad.ParseRule("if (calidad_producto is excelente) and (costo_total is regular) then puntaje_software is bueno");
                MamdaniFuzzyRule r15 = fsCostoCalidad.ParseRule("if (calidad_producto is muy_mala) and (costo_total is alto) then puntaje_software is muy_malo");
                MamdaniFuzzyRule r16 = fsCostoCalidad.ParseRule("if (calidad_producto is mala) and (costo_total is alto) then puntaje_software is muy_malo");
                MamdaniFuzzyRule r17 = fsCostoCalidad.ParseRule("if (calidad_producto is regular) and (costo_total is alto) then puntaje_software is malo");
                MamdaniFuzzyRule r18 = fsCostoCalidad.ParseRule("if (calidad_producto is buena) and (costo_total is alto) then puntaje_software is regular");
                MamdaniFuzzyRule r19 = fsCostoCalidad.ParseRule("if (calidad_producto is excelente) and (costo_total is alto) then puntaje_software is regular");
                MamdaniFuzzyRule r20 = fsCostoCalidad.ParseRule("if (calidad_producto is muy_mala) and (costo_total is muy_alto) then puntaje_software is muy_malo");
                MamdaniFuzzyRule r21 = fsCostoCalidad.ParseRule("if (calidad_producto is mala) and (costo_total is muy_alto) then puntaje_software is muy_malo");
                MamdaniFuzzyRule r22 = fsCostoCalidad.ParseRule("if (calidad_producto is regular) and (costo_total is muy_alto) then puntaje_software is malo");
                MamdaniFuzzyRule r23 = fsCostoCalidad.ParseRule("if (calidad_producto is buena) and (costo_total is muy_alto) then puntaje_software is malo");
                MamdaniFuzzyRule r24 = fsCostoCalidad.ParseRule("if (calidad_producto is excelente) and (costo_total is muy_alto) then puntaje_software is regular");



                fsCostoCalidad.Rules.Add(r0);
                fsCostoCalidad.Rules.Add(r1);
                fsCostoCalidad.Rules.Add(r2);
                fsCostoCalidad.Rules.Add(r3);
                fsCostoCalidad.Rules.Add(r4);
                fsCostoCalidad.Rules.Add(r5);
                fsCostoCalidad.Rules.Add(r6);
                fsCostoCalidad.Rules.Add(r7);
                fsCostoCalidad.Rules.Add(r8);
                fsCostoCalidad.Rules.Add(r9);
                fsCostoCalidad.Rules.Add(r10);
                fsCostoCalidad.Rules.Add(r11);
                fsCostoCalidad.Rules.Add(r12);
                fsCostoCalidad.Rules.Add(r13);
                fsCostoCalidad.Rules.Add(r14);
                fsCostoCalidad.Rules.Add(r15);
                fsCostoCalidad.Rules.Add(r16);
                fsCostoCalidad.Rules.Add(r17);
                fsCostoCalidad.Rules.Add(r18);
                fsCostoCalidad.Rules.Add(r19);
                fsCostoCalidad.Rules.Add(r20);
                fsCostoCalidad.Rules.Add(r21);
                fsCostoCalidad.Rules.Add(r22);
                fsCostoCalidad.Rules.Add(r23);
                fsCostoCalidad.Rules.Add(r24);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Parsing exception: {0}", ex.Message));
                //MessageBox.Show(string.Format("Parsing exception: {0}", ex.Message));
                return null;
            }
            return fsCostoCalidad;


        }


        public double obtenerCostoCalidad()
        {
            if (_fsCostoCalidad == null)
            {
                _fsCostoCalidad = CrearSistemaCostoCalidad();
                if (_fsCostoCalidad == null)
                {
                    return -1;
                }
            }

            FuzzyVariable fvCalidadProducto = _fsCostoCalidad.InputByName("calidad_producto");
            FuzzyVariable fvCostoTotal = _fsCostoCalidad.InputByName("costo_total");


            FuzzyVariable fvPuntajeSoftware = _fsCostoCalidad.OutputByName("puntaje_software");



            //
            // Associate input values with input variables
            //
            Dictionary<FuzzyVariable, double> inputValues = new Dictionary<FuzzyVariable, double>();
            inputValues.Add(fvCalidadProducto, this.valorCalidadProducto);
            inputValues.Add(fvCostoTotal, this.valorCostoTotal);

            //
            // Calculate result: one output value for each output variable
            //
            Dictionary<FuzzyVariable, double> result = _fsCostoCalidad.Calculate(inputValues);

            //
            // Get output value for the 'tips' variable
            //
            if (result[fvPuntajeSoftware].ToString("f1").Equals("NeuN"))
            {
                Console.WriteLine("ESTA MALO EL VALOR DE PUNTAJE DE SOFTWARE");
                return -1;
            }
            else
            {
                return result[fvPuntajeSoftware];
            }
        }
    }
}
