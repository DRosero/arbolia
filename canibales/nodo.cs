using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace canibales
{
    class nodo
    {
        
        int canibalesizq;
        int misionerosizq;
        int misionerosder;
        int canibalesder;
        int n_hijos;
        public static int Ngen = 0;
        public static int n_hijo;
        public static int Nodos = 0;
        Boolean ladobalsa;
        int calificacion;
        ArrayList nodos;
        public ArrayList camino;
        public int getcanibales()
        {
            return canibalesizq;
        }
        public int getmisioneros()
        {
            return misionerosizq;
        }
        public void setcalificacion(int cal)
        {
            this.calificacion = cal;
        }
        public nodo(int ncaniizq,int nmisioizq,int ncanider,int nmisioder,Boolean la)
        {
            canibalesizq = ncaniizq;
            misionerosizq = nmisioizq;
            ladobalsa = la;
            n_hijos = 0;
            canibalesder = ncanider;
            misionerosder = nmisioder;
            nodos = new ArrayList();
            camino = new ArrayList();
            calificacion = califi(this);
        }
        public nodo()
        {
            canibalesizq =0;
            misionerosizq = 0;
            ladobalsa = true;
            canibalesder = 0;
            n_hijos = 0;
            misionerosder = 0;
            nodos = new ArrayList();
            camino = new ArrayList();
            calificacion = califi(this);
        }
        public int califi(nodo actualcal)
        {
            return actualcal.misionerosizq + actualcal.misionerosder - actualcal.canibalesizq;
        }
        public void misionero()
        {
            nodo n = new nodo(this.canibalesizq, this.misionerosizq, this.canibalesder, this.misionerosder, this.ladobalsa);
            if (n.ladobalsa)
            {
                if (n.misionerosder > 0)
                {
                    n.misionerosder--;
                    n.misionerosizq++;
                    n.ladobalsa = false;
                }
            }
            else
            {
                if (n.misionerosizq > 0)
                {
                    n.misionerosizq--;
                    n.misionerosder++;
                    n.ladobalsa = true;
                }
            }
            /*if (/*this.vercamino(n)&& this.misionerosizq != n.misionerosizq && this.misionerosder != n.misionerosder && this.canibalesder != n.canibalesder && this.canibalesizq != n.canibalesizq
                &&n.canibalesder<n.misionerosder&&n.canibalesizq<n.misionerosizq) ingresa(n);*/
            if (this.misionerosizq == n.misionerosizq && this.misionerosder == n.misionerosder && this.canibalesder == n.canibalesder && this.canibalesizq == n.canibalesizq)
                return;
            else
            {
                if ((n.canibalesder <= n.misionerosder || n.misionerosder == 0) && (n.canibalesizq <= n.misionerosizq || n.misionerosizq == 0)&&n.vercamino(this)) ingresa(n);
            }
        }
        public Boolean vercamino(nodo n)
        {
            //nodo c = new nodo();
            foreach (nodo c in n.camino)
            {
                if (c.misionerosder == n.misionerosder && c.misionerosizq == n.misionerosizq && c.canibalesder == n.canibalesder && c.canibalesizq == n.canibalesizq && c.ladobalsa == n.ladobalsa)
                {
                    return false;
                }
            }
            return true;
            /*foreach (string name in myLinkedList)
            {
                Console.WriteLine(name);
            }
            for (Iterator y = this.camino.listIterator(); y.hasNext() == true; )
            {
                c = (nodo)y.next();
                if (n.x == c.x && n.y == c.y) return false;
            }*/
            
        }
        public void ingresa(nodo n)
        {
            this.nodos.Add(n);
            this.n_hijos++;
            Nodos++;
        }
        public void dosmisioneros()
        {
            nodo n = new nodo(this.canibalesizq, this.misionerosizq, this.canibalesder, this.misionerosder, this.ladobalsa);
            if (n.ladobalsa)
            {
                if (n.misionerosder > 1)
                {
                    n.misionerosder = n.misionerosder-2;
                    n.misionerosizq = n.misionerosizq + 2;
                    n.ladobalsa = false;
                }
            }
            else
            {
                if (n.misionerosizq > 1)
                {
                    n.misionerosizq = n.misionerosizq-2;
                    n.misionerosder = n.misionerosder+2;
                    n.ladobalsa = true;
                }
            }
           if (this.misionerosizq == n.misionerosizq && this.misionerosder == n.misionerosder && this.canibalesder == n.canibalesder && this.canibalesizq == n.canibalesizq)
                return;
            else
            {
                if ((n.canibalesder <= n.misionerosder || n.misionerosder == 0) && (n.canibalesizq <= n.misionerosizq || n.misionerosizq == 0) && n.vercamino(this)) ingresa(n);
            }
        }
        public void misionerocanibal()
        {
            nodo n = new nodo(this.canibalesizq, this.misionerosizq, this.canibalesder, this.misionerosder, this.ladobalsa);
            if (n.ladobalsa)
            {
                if (n.misionerosder > 0&&n.canibalesder>0)
                {
                    n.misionerosder--;
                    n.misionerosizq++;
                    n.canibalesder--;
                    n.canibalesizq++;
                    n.ladobalsa = false;
                }
            }
            else
            {
                if (n.misionerosizq > 0&&n.canibalesizq>0)
                {
                    n.misionerosder++;
                    n.misionerosizq--;
                    n.canibalesder++;
                    n.canibalesizq--;
                    n.ladobalsa = true;
                }
            }
            if (this.misionerosizq == n.misionerosizq && this.misionerosder == n.misionerosder && this.canibalesder == n.canibalesder && this.canibalesizq == n.canibalesizq)
                return;
            else
            {
                if ((n.canibalesder <= n.misionerosder || n.misionerosder == 0) && (n.canibalesizq <= n.misionerosizq || n.misionerosizq == 0) && n.vercamino(this)) ingresa(n);
            }
        }
        public void doscanibales()
        {
            nodo n = new nodo(this.canibalesizq, this.misionerosizq, this.canibalesder, this.misionerosder, this.ladobalsa);
            if (n.ladobalsa)
            {
                if (n.canibalesder > 1)
                {
                    n.canibalesder = n.canibalesder - 2;
                    n.canibalesizq = n.canibalesizq + 2;
                    n.ladobalsa = false;
                }
            }
            else
            {
                if (n.canibalesizq > 1)
                {
                    n.canibalesizq = n.canibalesizq - 2;
                    n.canibalesder = n.canibalesder + 2;
                    n.ladobalsa = true;
                }
            }
            if (this.misionerosizq == n.misionerosizq && this.misionerosder == n.misionerosder && this.canibalesder == n.canibalesder && this.canibalesizq == n.canibalesizq)
                return;
            else
            {
                if ((n.canibalesder <= n.misionerosder || n.misionerosder == 0) && (n.canibalesizq <= n.misionerosizq || n.misionerosizq == 0) && n.vercamino(this)) ingresa(n);
            }
        }
        public void canibal()
        {
            nodo n = new nodo(this.canibalesizq, this.misionerosizq, this.canibalesder, this.misionerosder, this.ladobalsa);
            if (n.ladobalsa)
            {
                if (n.canibalesder > 0)
                {
                    n.canibalesder--;
                    n.canibalesizq++;
                    n.ladobalsa = false;
                }
            }
            else
            {
                if (n.canibalesizq > 0)
                {
                    n.canibalesizq--;
                    n.canibalesder++;
                    n.ladobalsa = true;
                }
            }
            if (this.misionerosizq == n.misionerosizq && this.misionerosder == n.misionerosder && this.canibalesder == n.canibalesder && this.canibalesizq == n.canibalesizq)
                return;
            else
            {
                if ((n.canibalesder <= n.misionerosder || n.misionerosder == 0) && (n.canibalesizq <= n.misionerosizq || n.misionerosizq == 0)&&n.vercamino(this)) ingresa(n);
            }
        }
        public void opciones()
        {
            misionero();
            dosmisioneros();
            canibal();
            doscanibales();
            misionerocanibal();
        }

        public nodo checa_nodos()
        {
            if (this.n_hijos == 0)
            {
                n_hijo = 1;
                return this;
            }
            else
            {
                n_hijo = n_hijos;
                nodo n = new nodo();
                nodo c = new nodo();
                nodo aux = new nodo();
                nodo sig = new nodo();
                ArrayList auxiliar = new ArrayList();
                foreach (nodo w in nodos)
                {
                    auxiliar.Add(w);
                }
              /*  Random r = new Random();
                int i;
                do
                {
                    i=r.Next(0,nodos.Count-1);
                    if(this.vercamino2(this))
                        aux=(nodo)this.nodos[i];
                } while (aux == null);*/
                foreach(nodo z in this.nodos)
                {

                        if (z.vercamino2(this))
                        {
                            aux = z;
                        }
                    /*auxiliar.RemoveAt(0);
                    if (auxiliar.Count!=0)
                    {
                        sig  = (nodo)auxiliar[0];
                        if (z.calificacion >= sig.calificacion)
                        {
                            aux = sig;
                        }
                    }*/
                }
                aux.camino = this.camino;
                aux.camino.Add(this);
                Ngen++;
                //aux.n_hijos = n_hijo;
                return aux;
            }

        }
        public Boolean vercamino2(nodo n)
        {
            //nodo c = new nodo();
            foreach (nodo c in n.camino)
            {
                if (c.misionerosder == this.misionerosder && c.misionerosizq == this.misionerosizq && c.canibalesder == this.canibalesder && c.canibalesizq == this.canibalesizq && c.ladobalsa == this.ladobalsa)
                {
                    return false;
                }
            }
            return true;
        }
        public String ToString()
        {
            String cad="";
            foreach(nodo w in camino)
            {
                cad= cad+ w.camino.ToString();
            }
            return cad;
        }
        public void imprimir(nodo n)
        {
            foreach (nodo z in n.camino)
            {
                Console.WriteLine("can izquierdo {0} ,mis izquierdo {1} ,can derecho {2} , mis derecho {3}, lado balsa {4}",z.canibalesizq,z.misionerosizq,z.canibalesder,z.misionerosder,z.ladobalsa);
            }
        }
    }
}
