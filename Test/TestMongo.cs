using AutomatizadorSB.Modelo;
using AutomatizadorSB.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizadorSB.Test
{
    class TestMongo
    {
        public async Task insertarMensajeAsync() {

            MensajeRepository mr = new MensajeRepository();
            MensajeDto mensajeDto = new MensajeDto();
            mensajeDto.ClientMsgId = "34b363c2-b2b4-42f2-a8c4-39bae51e7ccc";
            //mensajeDto.Id = "";
            mensajeDto.team = "T39KSTY0N";
            mensajeDto.text = "prueba 2";
            mensajeDto.ts = "1600435618.000200";
            mensajeDto.type = "message";
            mensajeDto.user = "U01BLHH45DW";
            await mr.InsertarMensaje(mensajeDto);
        
        }

        public async Task seleccionarTodos()
        { 
            MensajeRepository mr = new MensajeRepository();
            List<MensajeDto> lista  = await mr.ObtenerMensajes();
            int cantidad = lista.Count;
        }

    }
}
