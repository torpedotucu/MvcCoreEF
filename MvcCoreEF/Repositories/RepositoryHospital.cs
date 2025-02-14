﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Data;
using MvcCoreEF.Models;
using System.Net.WebSockets;

namespace MvcCoreEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context=context;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Hospital>FindHospitalAsync(int idHospital)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital==idHospital
                           select datos;
            //SI NO LO ENCUENTRA DEBE DEVOLVER NULL
            if (consulta.Count()==0)
            {
                return null;
            }
            else
            {
                return await consulta.FirstAsync();
            }
           
        }

        public async Task InsertHospitalAsync(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            //Creamos UN MODEL
            Hospital hospital = new Hospital();
            hospital.IdHospital=idHospital;
            hospital.Nombre=nombre;
            hospital.Direccion=direccion;
            hospital.Telefono=telefono;
            hospital.Camas=camas;
            //AÑADIMOS EL MODEL A LA COLECCION DBSET DEL CONTEXTO
            await this.context.Hospitales.AddAsync(hospital);
            //INDICAMOS QUE ALMACENE LOS DATOS EN LA BBDD
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteHospitalAsync(int idHospital)
        {
            //BUSCAMOS EL MODEL PARA ELIMINARLO
            Hospital hospital = await this.FindHospitalAsync(idHospital);
            //ELIMINAMOS DE LA COLECCION DbSet<T> DEL CONTEXT
            this.context.Hospitales.Remove(hospital);
            //ACTUALIZAMOS LA BBDD
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateHospitalAsync
            (int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            //BUSCAMOS EL OBJETO HOSPITAL A MODIFICAR
            Hospital hospital = await this.FindHospitalAsync(idHospital);
            //SE PUEDE MODIFICAR LO QUE SE DESEÉ MENOS EL IDHOSPITAL (KEY)
            hospital.Nombre=nombre;
            hospital.Direccion=direccion;
            hospital.Telefono=telefono;
            hospital.Camas=camas;
            //NO EXISTE NINGUN METODO PARA REALIZAR UN UPDATE
            await this.context.SaveChangesAsync();
        }
    }
}
