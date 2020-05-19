using Microsoft.EntityFrameworkCore;
using RegistroPersonaBlazor.DAL;
using RegistroPersonaBlazor.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroPersonaBlazor.BLL
{
    public class PersonaControllers
    {
        private readonly Contexto db;

        public PersonaControllers()
        {
            db = new Contexto();
        }

        public bool Guardar(Personas personas)
        {
            bool paso = false;
            try
            {
                if (db.Personas.Add(personas) != null)
                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public bool Modificar(Personas personas)
        {
            bool paso = false;

            try
            {
                db.Entry(personas).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public bool Eliminar(int ID)
        {
            bool paso = false;
            try
            {
                var aux = db.Personas.Find(ID);
                db.Personas.Remove(aux);

                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }


            return paso;
        }

        public Personas Buscar(int ID)
        {
            Personas personas = new Personas();

            try
            {
                personas = db.Personas.Find(ID);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return personas;
        }

        public List<Personas> GetList(Expression<Func<Personas, bool>> persona)
        {
            List<Personas> lista = new List<Personas>();
            try
            {
                lista = db.Personas.Where(persona).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
