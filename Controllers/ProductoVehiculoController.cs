using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modulo_Productos.DOM;
using Modulo_Productos.Entities;
using System.Drawing;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Modulo_Productos.Controllers
{
    [Route("producto/vehiculo")]
    [ApiController]
    public class ProductoVehiculoController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;
        private List<TipoVehiculo> _listTipoVehiculo;
        private List<TipoCombustible> _listTipoCombustible;
        private List<Vehiculo> _listVehiculo;
        private List<Producto> _listProducto;
        private List<Modelo> _listModelo;
        private List<Marca> _listMarca;
        private List<FotoProducto> _listFotoProducto;

        public ProductoVehiculoController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/<ProductoVehiculoController>
        [HttpGet]
        public IEnumerable<VehiculoEnVenta> Get(string? color = "", string? marca = "")
        {
            List<VehiculoEnVenta> listaVehiculosVenta = new List<VehiculoEnVenta>();
            _listFotoProducto = _context.FotoProductos.ToList();
            _listTipoCombustible = _context.TipoCombustibles.ToList();
            _listTipoVehiculo = _context.TipoVehiculos.ToList();
            _listVehiculo = _context.Vehiculos.ToList();
            _listProducto = _context.Productos.ToList();
            _listModelo = _context.Modelos.ToList();
            _listMarca = _context.Marcas.ToList();
            foreach (Vehiculo vehiculo in _listVehiculo)
            {
                var producto = _listProducto.Find(x => x.Id == vehiculo.ProductoId);
                if (producto != null)
                {
                    var vehiculoEnVenta = new VehiculoEnVenta();
                    vehiculoEnVenta.idVehiculo = (int?)vehiculo.Id;
                    vehiculoEnVenta.idDuenio = (int?)vehiculo.IdDuenio;
                    vehiculoEnVenta.placa = vehiculo.Placa;
                    vehiculoEnVenta.idProducto = (int?)vehiculo.ProductoId;
                    vehiculoEnVenta.nombreProducto = producto.Nombre;
                    vehiculoEnVenta.chasis = vehiculo.Chasis;
                    vehiculoEnVenta.color = vehiculo.Color ?? "";
                    vehiculoEnVenta.precio = vehiculo.Precio;
                    vehiculoEnVenta.idModelo = (int?)vehiculo.ModeloId;
                    var modelo = _listModelo.Find(y => y.Id == vehiculo.ModeloId);
                    if (modelo != null)
                    {
                        vehiculoEnVenta.modelo = modelo.Nombre;
                        var marcaVehiculo = _listMarca.Find(q => q.Id == modelo.MarcaId);
                        if (marcaVehiculo != null)
                        {
                            vehiculoEnVenta.marca = marcaVehiculo.Nombre;
                            vehiculoEnVenta.idMarca = (int?)marcaVehiculo.Id;
                        }
                    }
                    var tipoVehiculo = _listTipoVehiculo.Find(w => w.Id == vehiculo.TipoVehiculoId);
                    if (tipoVehiculo != null)
                    {
                        vehiculoEnVenta.tipoVehiculo = tipoVehiculo.Nombre;
                        vehiculoEnVenta.idTipoVehiculo = (int?)tipoVehiculo.Id;
                    }
                    var tipoCombustible = _listTipoCombustible.Find(e => e.Id == vehiculo.TipoCombustibleId);
                    if (tipoCombustible != null)
                    {
                        vehiculoEnVenta.tipoCombustible = tipoCombustible.Nombre;
                        vehiculoEnVenta.idTipoCombustible = (int?)tipoCombustible.Id;
                    }
                    var fotografia = _listFotoProducto.Find(z => z.ProductoId == producto.Id);
                    if (fotografia != null)
                    {
                        vehiculoEnVenta.urlFotografia = fotografia.Url;
                    }
                    listaVehiculosVenta.Add(vehiculoEnVenta);
                }
            }
            if (!string.IsNullOrEmpty(color))
            {
                listaVehiculosVenta = listaVehiculosVenta.FindAll(x => string.Equals(x.color.ToLower(), color.ToLower()));
            }
            if (!string.IsNullOrEmpty(marca))
            {
                listaVehiculosVenta = listaVehiculosVenta.FindAll(x => string.Equals(x.marca.ToLower(), marca.ToLower()));
            }
            return listaVehiculosVenta;
        }

        // GET api/<ProductoVehiculoController>/5
        [HttpGet("{id}")]
        public VehiculoEnVenta Get(int id)
        {
            _listFotoProducto = _context.FotoProductos.ToList();
            _listTipoCombustible = _context.TipoCombustibles.ToList();
            _listTipoVehiculo = _context.TipoVehiculos.ToList();
            _listVehiculo = _context.Vehiculos.ToList();
            _listProducto = _context.Productos.ToList();
            _listModelo = _context.Modelos.ToList();
            _listMarca = _context.Marcas.ToList();
            var vehiculo = _listVehiculo.Find(x => x.Id == id);
            var vehiculoEnVenta = new VehiculoEnVenta();
            if (vehiculo != null)
            {
                var producto = _listProducto.Find(x => x.Id == vehiculo.ProductoId);
                if (producto != null)
                {

                    vehiculoEnVenta.idVehiculo = (int?)vehiculo.Id;
                    vehiculoEnVenta.idDuenio = (int?)vehiculo.IdDuenio;
                    vehiculoEnVenta.placa = vehiculo.Placa;
                    vehiculoEnVenta.idProducto = (int?)vehiculo.ProductoId;
                    vehiculoEnVenta.nombreProducto = producto.Nombre;
                    vehiculoEnVenta.chasis = vehiculo.Chasis;
                    vehiculoEnVenta.color = vehiculo.Color ?? "";
                    vehiculoEnVenta.precio = vehiculo.Precio;
                    vehiculoEnVenta.idModelo = (int?)vehiculo.ModeloId;
                    var modelo = _listModelo.Find(y => y.Id == vehiculo.ModeloId);
                    if (modelo != null)
                    {
                        vehiculoEnVenta.modelo = modelo.Nombre;
                        var marcaVehiculo = _listMarca.Find(q => q.Id == modelo.MarcaId);
                        if (marcaVehiculo != null)
                        {
                            vehiculoEnVenta.marca = marcaVehiculo.Nombre;
                            vehiculoEnVenta.idMarca = (int?)marcaVehiculo.Id;
                        }
                    }
                    var tipoVehiculo = _listTipoVehiculo.Find(w => w.Id == vehiculo.TipoVehiculoId);
                    if (tipoVehiculo != null)
                    {
                        vehiculoEnVenta.tipoVehiculo = tipoVehiculo.Nombre;
                        vehiculoEnVenta.idTipoVehiculo = (int?)tipoVehiculo.Id;
                    }
                    var tipoCombustible = _listTipoCombustible.Find(e => e.Id == vehiculo.TipoCombustibleId);
                    if (tipoCombustible != null)
                    {
                        vehiculoEnVenta.tipoCombustible = tipoCombustible.Nombre;
                        vehiculoEnVenta.idTipoCombustible = (int?)tipoCombustible.Id;
                    }
                    var fotografia = _listFotoProducto.Find(z => z.ProductoId == producto.Id);
                    if (fotografia != null)
                    {
                        vehiculoEnVenta.urlFotografia = fotografia.Url;
                    }
                }
            }


            return vehiculoEnVenta;
        }

        // POST api/<ProductoVehiculoController>
        [HttpPost]
        public void Post([FromBody] VehiculoEnVenta nuevoVehiculo)
        {
            var nuevoProducto = new Producto();
            nuevoProducto.Nombre = nuevoVehiculo.modelo;
            nuevoProducto = _context.Productos.Add(nuevoProducto).Entity;
            _context.SaveChanges();
            var vehiculoAgregar = new Vehiculo();
            var fotografia = new FotoProducto();
            fotografia.ProductoId = nuevoProducto.Id;
            fotografia.Url = nuevoVehiculo.urlFotografia ?? "";
            fotografia = _context.FotoProductos.Add(fotografia).Entity;
            _context.SaveChanges();
            vehiculoAgregar.Chasis = nuevoVehiculo.chasis ?? "";
            vehiculoAgregar.ModeloId = (long)nuevoVehiculo.idModelo;
            vehiculoAgregar.Placa = nuevoVehiculo.placa ?? "";
            vehiculoAgregar.Color = nuevoVehiculo.color ?? "";
            vehiculoAgregar.Precio = (double)nuevoVehiculo.precio;
            vehiculoAgregar.TipoCombustibleId = (long)nuevoVehiculo.idTipoCombustible;
            vehiculoAgregar.TipoVehiculoId = (long)nuevoVehiculo.idTipoVehiculo;
            vehiculoAgregar.ProductoId = nuevoProducto.Id;
            vehiculoAgregar = _context.Vehiculos.Add(vehiculoAgregar).Entity;
            _context.SaveChanges();

        }

        // PUT api/<ProductoVehiculoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VehiculoEnVenta nuevoVehiculo)
        {
            _listVehiculo = _context.Vehiculos.ToList();
            _listProducto = _context.Productos.ToList();
            var vehiculo = _listVehiculo.Find(x => x.Id == id);
            if (vehiculo != null)
            {
                var producto = _listProducto.Find(x => x.Id == vehiculo.ProductoId);
                if (producto != null)
                {
                    vehiculo.Chasis = nuevoVehiculo.chasis ?? vehiculo.Chasis;
                    vehiculo.ModeloId = (long)nuevoVehiculo.idModelo;
                    vehiculo.Placa = nuevoVehiculo.placa ?? vehiculo.Placa;
                    vehiculo.Color = nuevoVehiculo.color ?? vehiculo.Color;
                    vehiculo.Precio = (double)nuevoVehiculo.precio;
                    vehiculo.TipoCombustibleId = (long)nuevoVehiculo.idTipoCombustible;
                    vehiculo.TipoVehiculoId = (long)nuevoVehiculo.idTipoVehiculo;
                    _context.Entry(vehiculo).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }

        }

        // DELETE api/<ProductoVehiculoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _listVehiculo = _context.Vehiculos.ToList();
            _listProducto = _context.Productos.ToList();
            _listFotoProducto = _context.FotoProductos.ToList();
            var vehiculo = _listVehiculo.Find(x => x.Id == id);
            if (vehiculo != null)
            {
                var producto = _listProducto.Find(x => x.Id == vehiculo.ProductoId);
                if (producto != null)
                {
                    var fotografia = _listFotoProducto.Find(l => l.ProductoId == producto.Id);
                    if (fotografia != null)
                    {
                        _context.FotoProductos.Remove(fotografia);
                        _context.SaveChanges();
                    }
                    vehiculo.ProductoId = null;
                    _context.Entry(vehiculo).State = EntityState.Modified;
                    _context.SaveChanges();
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                }
            }
        }
    }
}
