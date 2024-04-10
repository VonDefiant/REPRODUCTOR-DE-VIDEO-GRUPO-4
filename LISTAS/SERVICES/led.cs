using LISTAS.MODELS;
using System.Collections.Generic;

namespace LISTAS.SERVICES
{
    public class Led
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }
        public Nodo? NodoActual { get; set; }

        public Led()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            NodoActual = null;
        }

        public bool IsEmpty => PrimerNodo == null;

        public string AgregarNodoAlInicio(Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaSiguiente = PrimerNodo;
                PrimerNodo.LigaAnterior = nuevoNodo;
                PrimerNodo = nuevoNodo;
            }

            NodoActual = nuevoNodo;
            return "Nodo agregado al inicio de la lista";
        }

        public Nodo Siguiente()
        {
            NodoActual = NodoActual.LigaSiguiente ?? UltimoNodo;

            return NodoActual;
        }

        public Nodo Anterior()
        {
            NodoActual = NodoActual?.LigaAnterior ?? PrimerNodo;

            return NodoActual;
        }

        public string AgregarNodoAlFinal(Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.LigaSiguiente = nuevoNodo;
                nuevoNodo.LigaAnterior = UltimoNodo;
                UltimoNodo = nuevoNodo;
            }

            NodoActual = nuevoNodo;
            return "Nodo agregado al final de la lista";
        }

        public string EliminarNodoAlInicio()
        {
            if (IsEmpty)
            {
                return "La lista está vacía, no se puede eliminar ningún nodo.";
            }
            else if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                PrimerNodo = PrimerNodo.LigaSiguiente;
                PrimerNodo.LigaAnterior = null;
            }

            NodoActual = PrimerNodo;
            return "Nodo eliminado del inicio de la lista";
        }

        public string EliminarNodoAlFinal()
        {
            if (IsEmpty)
            {
                return "La lista está vacía, no se puede eliminar ningún nodo.";
            }
            else if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                UltimoNodo = UltimoNodo.LigaAnterior;
                UltimoNodo.LigaSiguiente = null;
            }

            NodoActual = UltimoNodo;
            return "Nodo eliminado del final de la lista";
        }

        public IEnumerable<(int Position, string VideoName)> GetNodesWithPositions()
        {
            var currentNode = PrimerNodo;
            int position = 1;
            while (currentNode != null)
            {
                yield return (position, currentNode.Informacion);
                currentNode = currentNode.LigaSiguiente;
                position++;
            }
        }
    }
}
