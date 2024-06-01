async function EditarTarea(identificador) {
    const data = {
        Identificador: identificador
    };

    try {
        const response = await fetch('/Tarea/ConsultarPorId', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error('Error en la solicitud: ' + response.statusText);

            // Aplicar Sweet alert
        }

        const resultHtml = await response.text();
        document.getElementById('edit').innerHTML = resultHtml;
    } catch (error) {
        console.error('Error:', error);
    }
};
async function FiltarDocumentos() {
    $("#query").empty();
    $("#edit").empty();

    try {
        const response = await fetch('/Tarea/FiltrarDocumentos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error('Error en la solicitud: ' + response.statusText);

            // Aplicar Sweet alert
        }

        const resultHtml = await response.text();
        document.getElementById('query').innerHTML = resultHtml;
    } catch (error) {
        console.error('Error:', error);
    }
};

async function ConsultarTodos() {
    $("#edit").empty();

    const titulo = document.getElementById('TituloContieneFiltro').value;

    const data = {
        TituloContiene: titulo
    };

    try {
        const response = await fetch('/Tarea/ConsultarTodos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error('Error en la solicitud: ' + response.statusText);

            // Aplicar Sweet alert
        }

        const resultHtml = await response.text();
        document.getElementById('tabla-resultado').innerHTML = resultHtml;
    } catch (error) {
        console.error('Error:', error);
    }
}
async function ConsultarPorId(idControl) {
    $("#query").empty();
    $("#edit").empty();

    let identificador = idControl.split('|')[0];
    EditarTarea(identificador);
}
async function Crear() {
    $("#query").empty();

    const data = {
        Titulo: document.getElementById('titulo').value,
        Descripcion: document.getElementById('descripcion').value,
        FechaVencimiento: document.getElementById('fechaVencimiento').value
    };

    try {
        const response = await fetch('/Tarea/Crear', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error('Error en la solicitud: ' + response.statusText);

            // Aplicar Sweet alert
        }

        // retornar a pantalla principal
        FiltarDocumentos();

    } catch (error) {
        console.error('Error:', error);
    }
}
async function Actualizar() {
    $("#query").empty();

    const identificador = document.getElementById('identificador').value;
    const titulo = document.getElementById('titulo').value;
    const descripcion = document.getElementById('descripcion').value;
    const fechaVencimiento = (new Date(document.getElementById('fechaVencimiento').value)).toISOString();

    const data = {
        Identificador: identificador,
        Titulo: titulo,
        Descripcion: descripcion,
        FechaVencimiento: fechaVencimiento
    };

    try {
        const response = await fetch('/Tarea/Actualizar', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error('Error en la solicitud: ' + response.statusText);

            // Aplicar Sweet alert
        }

        // retornar a pantalla principal
        EditarTarea(identificador);

    } catch (error) {
        console.error('Error:', error);
    }
}
async function Eliminar(idControl) {
    $("#query").empty();

    const data = {
        Identificador: idControl.split('|')[0],
    };

    try {
        const response = await fetch('/Tarea/Eliminar', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error('Error en la solicitud: ' + response.statusText);

            // Aplicar Sweet alert
        }

        // retornar a pantalla principal
        FiltarDocumentos();

    } catch (error) {
        console.error('Error:', error);
    }
}
async function Completar() {
    $("#query").empty();

    const identificador = document.getElementById('identificador').value;
    const data = {
        Identificador: identificador,
    };

    try {
        const response = await fetch('/Tarea/Completar', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error('Error en la solicitud: ' + response.statusText);

            // Aplicar Sweet alert
        }

        // retornar a pantalla principal
        EditarTarea(identificador);

    } catch (error) {
        console.error('Error:', error);
    }
}
async function GenerarNuevo() {
    $("#query").empty();

    try {
        const response = await fetch('/Tarea/GenerarNuevo', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
        });

        if (!response.ok) {
            throw new Error('Error en la solicitud: ' + response.statusText);

            // Aplicar Sweet alert
        }

        const resultHtml = await response.text();
        document.getElementById('edit').innerHTML = resultHtml;

    } catch (error) {
        console.error('Error:', error);
    }
}