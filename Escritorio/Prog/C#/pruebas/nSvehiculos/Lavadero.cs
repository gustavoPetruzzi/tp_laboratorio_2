namespace nSvehiculos
{
    public class Lavadero
    {
        private List<Vehiculo> _vehiculos;
        private float _precioAuto;
        private float _precioCamion;
        private float _precioMoto;
        
        private Lavadero()
        {
            this._vehiculos = new list<Vehiculo>();
        }
        
        public Lavadero(float precioAuto, float precioCamion, float precioMoto):this()
        {
            this._precioAuto = precioAuto;
            this._precioCamion = precioCamion;
            this._precioMoto = precioMoto;
        }
        
        public Lavadero
        {
            get
            {
                String retorno;
                retorno = string.Format("precioAuto: {0} -precioCamion: {1} - precioMoto: {2}", this._precioAuto, this.precioCamion, this.precioMoto);
                foreach(Vehiculo vehiculo in this._vehiculos)
                {
                    if(vehiculo is Auto)
                    {
                        Moto miMoto = (moto) vehiculo;
                        ret
                    }
                }
                retorno.ToString();
            }
        }
        
        public statin Boolean operator ==(Lavadero lavadero, Vehiculo vehiculo)
        {
            Boolean retorno = false;
            for(int i = 0; i<lavadero._vehiculos.Count; i++)
            {
                if(lavadero._vehiculos[i] == vehiculo)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static Boolean operator !=(Lavadero lavadero, Vehiculo vehiculo)
        {
            returno !(lavadero vehiculo);
        }
        
        public static Lavadero operator +(Lavadero lavadero, Vehiculo vehiculo)
        {
            if(lavadero != vehiculo)
            {
                lavadero._vehiculos.add(vehiculo);
            }
            return lavadero;
        }
        
        public static Lavadero operator -(Lavadero lavadero, Vehiculo vehiculo)
        {
            if(lavadero == vehiculo)
            {
                lavadero._vehiculos.remove(vehiculo);
            }
            return lavadero;
        }
    }
}