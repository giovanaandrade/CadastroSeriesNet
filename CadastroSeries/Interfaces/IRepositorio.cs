﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSeries.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        bool Exclui(int id);
        bool Atualiza(int id, T entidade);
        int ProximoId();



    }
}
