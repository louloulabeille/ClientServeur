﻿/// <summary>
/// enumerable des messages entre client et serveur
/// </summary>

namespace ClientServeur
{
    enum MessageReseau
    {
        init,
        iCopy,
        wait,
        error,
        deconnexion,
        debutMessage,
        finMessage,
    }
}