using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modulo_Productos.DOM;
using Modulo_Productos.Entities;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Modulo_Productos.Controllers
{
    [Route("producto/repuesto")]
    [ApiController]
    public class ProductoRepuestoController : ControllerBase
    {
        private readonly ProductosServiciosVehiculosContext _context;
        private List<Repuesto> _listRepuesto;
        private List<Producto> _listProducto;
        private List<Modelo> _listModelo;
        private List<Marca> _listMarca;
        private List<FotoProducto> _listFotoProducto;
        private List<DisponibilidadRepuesto> _listDisponibilidad;

        public ProductoRepuestoController(ProductosServiciosVehiculosContext context)
        {
            _context = context;
        }
        // GET: api/<ProductoParteController>
        [HttpGet]
        public IEnumerable<RepuestoEnVenta> Get(string? marca="")
        {
            var listaRepuestos = new List<RepuestoEnVenta>();
            _listRepuesto = _context.Repuestos.ToList();
            _listProducto = _context.Productos.ToList();
            _listModelo = _context.Modelos.ToList();
            _listMarca = _context.Marcas.ToList();
            _listFotoProducto = _context.FotoProductos.ToList();
            _listDisponibilidad = _context.DisponibilidadRepuestos.ToList();

            foreach (Repuesto repuesto in _listRepuesto)
            {
                var producto = _listProducto.Find(x => x.Id == repuesto.ProductoId);
                if (producto != null)
                {
                    var nuevoRepuestoEnVenta = new RepuestoEnVenta();
                    var modelo = _listModelo.Find(y => y.Id == repuesto.ModeloId);
                    var marca_db = _listMarca.Find(x => x.Id == modelo.MarcaId);
                    var foto = _listFotoProducto.Find(x => x.ProductoId == producto.Id);
                    var disponibilidad = _listDisponibilidad.Find(y => y.RepuestoId == repuesto.Id);

                    nuevoRepuestoEnVenta.idRepuesto = (int?)repuesto.Id;
                    nuevoRepuestoEnVenta.idProducto = (int?)producto.Id;
                    nuevoRepuestoEnVenta.idModelo = (int?)modelo.Id;
                    nuevoRepuestoEnVenta.idMarca = (int?)modelo.MarcaId;
                    nuevoRepuestoEnVenta.idDisponibilidad = (int?)disponibilidad.Id;
                    nuevoRepuestoEnVenta.idFoto = (int?)foto.Id;
                    nuevoRepuestoEnVenta.nombreDescripcionRepuesto = repuesto.Nombre;
                    nuevoRepuestoEnVenta.precio = repuesto.Precio;
                    nuevoRepuestoEnVenta.nombreProducto = producto.Nombre;
                    nuevoRepuestoEnVenta.unidadesDisponibles = (int?)disponibilidad.UnidadesDisponibles;
                    nuevoRepuestoEnVenta.idSucursal = (int?)disponibilidad.IdSucursal;
                    nuevoRepuestoEnVenta.marca = marca_db.Nombre;
                    nuevoRepuestoEnVenta.modelo = modelo.Nombre;
                    nuevoRepuestoEnVenta.urlFotografia = foto.Url;
                    listaRepuestos.Add(nuevoRepuestoEnVenta);
                }
            }
            if (!string.IsNullOrEmpty(marca)) {
                listaRepuestos = listaRepuestos.FindAll(x => string.Equals(x.marca.ToLower(), marca.ToLower()));
            }
            return listaRepuestos;
        }

        // GET api/<ProductoParteController>/5
        [HttpGet("{id}")]
        public RepuestoEnVenta Get(int id)
        {
            _listRepuesto = _context.Repuestos.ToList();
            _listProducto = _context.Productos.ToList();
            _listModelo = _context.Modelos.ToList();
            _listMarca = _context.Marcas.ToList();
            _listFotoProducto = _context.FotoProductos.ToList();
            _listDisponibilidad = _context.DisponibilidadRepuestos.ToList();
            var nuevoRepuestoEnVenta = new RepuestoEnVenta();
            var repuesto = _listRepuesto.Find(x => x.Id == id);
            if (repuesto != null)
            {
                var producto = _listProducto.Find(x => x.Id == repuesto.ProductoId);
                if (producto != null)
                {

                    var modelo = _listModelo.Find(y => y.Id == repuesto.ModeloId);
                    var marca = _listMarca.Find(x => x.Id == modelo.MarcaId);
                    var foto = _listFotoProducto.Find(x => x.ProductoId == producto.Id);
                    var disponibilidad = _listDisponibilidad.Find(y => y.RepuestoId == repuesto.Id);

                    nuevoRepuestoEnVenta.idRepuesto = (int?)repuesto.Id;
                    nuevoRepuestoEnVenta.idProducto = (int?)producto.Id;
                    nuevoRepuestoEnVenta.idModelo = (int?)modelo.Id;
                    nuevoRepuestoEnVenta.idMarca = (int?)modelo.MarcaId;
                    nuevoRepuestoEnVenta.idDisponibilidad = (int?)disponibilidad.Id;
                    nuevoRepuestoEnVenta.idFoto = (int?)foto.Id;
                    nuevoRepuestoEnVenta.nombreDescripcionRepuesto = repuesto.Nombre;
                    nuevoRepuestoEnVenta.precio = repuesto.Precio;
                    nuevoRepuestoEnVenta.nombreProducto = producto.Nombre;
                    nuevoRepuestoEnVenta.unidadesDisponibles = (int?)disponibilidad.UnidadesDisponibles;
                    nuevoRepuestoEnVenta.idSucursal = (int?)disponibilidad.IdSucursal;
                    nuevoRepuestoEnVenta.marca = marca.Nombre;
                    nuevoRepuestoEnVenta.modelo = modelo.Nombre;
                    nuevoRepuestoEnVenta.urlFotografia = foto.Url;
                }
            }
            return nuevoRepuestoEnVenta;

        }

        // POST api/<ProductoParteController>
        [HttpPost]
        public void Post([FromBody] RepuestoEnVenta nuevoRepuesto)
        {
            var producto = new Producto();
            producto.Nombre = nuevoRepuesto.nombreProducto;
            producto = _context.Productos.Add(producto).Entity;
            _context.SaveChanges();
            var fotografia = new FotoProducto();
            fotografia.ProductoId = producto.Id;
            fotografia.Url = nuevoRepuesto.urlFotografia;
            fotografia = _context.FotoProductos.Add(fotografia).Entity;
            _context.SaveChanges();
            var repuesto = new Repuesto();
            repuesto.ProductoId = producto.Id;
            repuesto.ModeloId = (long)nuevoRepuesto.idModelo;
            repuesto.Nombre = nuevoRepuesto.nombreDescripcionRepuesto;
            repuesto.Precio = (double)nuevoRepuesto.precio;
            repuesto = _context.Repuestos.Add(repuesto).Entity;
            _context.SaveChanges();
            var disponibilidad = new DisponibilidadRepuesto();
            disponibilidad.RepuestoId = repuesto.Id;
            disponibilidad.UnidadesDisponibles = (int)nuevoRepuesto.unidadesDisponibles;
            disponibilidad.IdSucursal = (long)nuevoRepuesto.idSucursal;
            disponibilidad = _context.DisponibilidadRepuestos.Add(disponibilidad).Entity;
            _context.SaveChanges();

        }

        // PUT api/<ProductoParteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RepuestoEnVenta nuevoRepuesto)
        {
            _listRepuesto = _context.Repuestos.ToList();
            _listProducto = _context.Productos.ToList();
            _listDisponibilidad = _context.DisponibilidadRepuestos.ToList();
            _listFotoProducto = _context.FotoProductos.ToList();
            var repuesto = _listRepuesto.Find(x => x.Id == id);
            if (repuesto != null)
            {
                var producto = _listProducto.Find(x => x.Id == repuesto.ProductoId);
                if (producto != null)
                {
                    var fotografia = _listFotoProducto.Find(x => x.ProductoId == producto.Id);
                    fotografia.Url = nuevoRepuesto.urlFotografia;
                    var disponibilidad = _listDisponibilidad.Find(x => x.RepuestoId == repuesto.Id);
                    disponibilidad.UnidadesDisponibles = (int)nuevoRepuesto.unidadesDisponibles;
                    _context.Entry(fotografia).State = EntityState.Modified;
                    _context.SaveChanges();
                    _context.Entry(disponibilidad).State = EntityState.Modified;
                    _context.SaveChanges();
                    repuesto.Precio = (double)nuevoRepuesto.precio;
                    repuesto.Nombre = nuevoRepuesto.nombreDescripcionRepuesto;
                    producto.Nombre = nuevoRepuesto.nombreProducto;
                    _context.Entry(producto).State = EntityState.Modified;
                    _context.SaveChanges();
                    _context.Entry(repuesto).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }

        // DELETE api/<ProductoParteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _listRepuesto = _context.Repuestos.ToList();
            _listProducto = _context.Productos.ToList();
            _listDisponibilidad = _context.DisponibilidadRepuestos.ToList();
            _listFotoProducto = _context.FotoProductos.ToList();
            var repuesto = _listRepuesto.Find(x => x.Id == id);
            if (repuesto != null)
            {
                var producto = _listProducto.Find(x => x.Id == repuesto.ProductoId);
                if (producto != null)
                {
                    var fotografia = _listFotoProducto.Find(x => x.ProductoId == producto.Id);
                    var disponibilidad = _listDisponibilidad.Find(x => x.RepuestoId == repuesto.Id);
                    if (disponibilidad != null)
                    {
                        _context.DisponibilidadRepuestos.Remove(disponibilidad);
                        _context.SaveChanges();
                    }
                    if (fotografia != null)
                    {
                        _context.FotoProductos.Remove(fotografia);
                        _context.SaveChanges();
                    }
                    _context.Repuestos.Remove(repuesto);
                    _context.SaveChanges();
                    _context.Productos.Remove(producto);
                }
            }
        }
    }
}
