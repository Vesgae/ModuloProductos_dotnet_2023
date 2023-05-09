namespace Modulo_Productos.DOM
{
    public class RepuestoEnVenta
    {
        public int? idRepuesto { get; set; } = 0;
        public string? nombreDescripcionRepuesto { get; set; } = "";
        public double? precio { get; set; } = 0;
        public int? idProducto { get; set; } = 0;
        public string? nombreProducto { get; set; } = "";
        public int? idDisponibilidad { get; set; } = 0;
        public int? idSucursal { get; set; } = 0;
        public int? unidadesDisponibles { get; set; } = 0;
        public int? idFoto { get; set; } = 0;
        public string? urlFotografia { get; set; } = "";
        public int? idModelo { get; set; } = 0;
        public string? modelo { get; set; } = "";
        public string? marca { get; set; } = "";
        public int? idMarca { get; set; } = 0;
    }
}
