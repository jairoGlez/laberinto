using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace laberinto
{
    public partial class Formulario_Juego : Form
    {
        Tablero tablero;
        Personaje[] personajes;
        Tabla_laberinto tabla;
        bool juego_iniciado;
        int personaje_seleccionado;
        int visita;
        bool modo_manual;
        private bool nonNumberEntered;
        private Form_Prioridad config_prioridad;
        private string tipo_distancia;
        private Bitmap imagen_meta;

        public Formulario_Juego()
        {
            tipo_distancia = "";
            InitializeComponent();
            config_prioridad = new Form_Prioridad();
            config_prioridad.FormClosing += new FormClosingEventHandler(cerrar_prioridad);
            poner_prioridades();
            comboBox_Algoritmo_Busqueda.SelectedIndex = 0;
            var dibujo = Image.FromFile(@"Recursos\meta.png");
            imagen_meta = new Bitmap(dibujo, new Size(35, 35));
        }

        private void cerrar_prioridad(object sender, FormClosingEventArgs e)
        {
            poner_prioridades();
        }

        private List<string[]> mostrar_ventana_cargar()
        {
            var ventana = new Form_Inicio();
            ventana.ShowDialog();
            return ventana.filas_leidas();
        }
        private void mostrar_ventana_configuracion()
        {
            var ventana = new Form_Configuracion(tablero.texturas_asignadas);
            ventana.FormClosing += new FormClosingEventHandler(config_terminada);
            ventana.ShowDialog();
        }
        private void config_terminada(object sender, EventArgs e)
        {
            var ventana = sender as Form_Configuracion;
            var temp_terrenos = ventana.terrenos_valuados;

            if (temp_terrenos.Count == 0)
            {
                Utilidades.mensaje_de_error("Error en la configuración de las texturas");
                return;
            }
            tablero.texturas_asignadas = temp_terrenos;

            dibujar_laberinto();
            agregar_opciones_a_combos_coordenadas();
        }
        private void Formulario_Juego_Shown(object sender, EventArgs e)
        {
            iniciar_configuracion();
        }
        private void iniciar_configuracion()
        {
            var filas = mostrar_ventana_cargar();
            if (filas == null)
            {
                Utilidades.mensaje_de_error("Error en la configuracion del laberinto");
                return;
            }
            this.tablero = new Tablero(filas);
            mostrar_ventana_configuracion();
            cargar_personajes();
            agregar_personajes_al_combo();
        }
        private void cargar_personajes()
        {
            var nombres_de_archivos = Directory.GetFiles("Personajes", "*.png");
            List<Personaje> personajes_cargados = new List<Personaje>();
            foreach(string archivo in nombres_de_archivos)
            {
                Personaje p = new Personaje(archivo);
                p.cargar_costos(tablero.texturas_asignadas);
                Image avatar = Image.FromFile(archivo);
                p.imagen = new Bitmap(avatar, new Size(30, 30));
                personajes_cargados.Add(p);
            }
            this.personajes = personajes_cargados.ToArray();
        }
        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
        private void button_Jugar_Click(object sender, EventArgs e)
        {
            if(!actualizar_costos()) return; 
            tipo_distancia = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag as string;
            bloquear_controles();
            this.Focus();
            juego_iniciado = true;
            boton_reiniciar.Enabled = true;
            visita = 2;
            verificar_victoria();
            enmascarar_todo();
            var metodo_seleccionado = comboBox_Algoritmo_Busqueda.SelectedItem.ToString();
            modo_manual = false;
            switch (metodo_seleccionado)
            {
                case "Profundidad":
                    busqueda_profundidad_recursiva();
                    break;
                case "Manual":
                    modo_manual = true;
                    break;
                case "Voraz primero el mejor":
                    voraz_primero_el_mejor();
                    break;
                case "Coste uniforme":
                    coste_uniforme();                    
                    break;
                case "A*":
                    a_estrella();
                    break;
                default:
                    break;
            }
        }
        private double calcular_distancia(Dictionary<string, int> origen, Dictionary<string, int> destino)
        {
            var tipo_de_distancia = tipo_distancia;
            double costo;
            if(tipo_de_distancia == "Manhattan")
            {
                costo = Math.Abs(origen["fila"] - destino["fila"]) + Math.Abs(origen["columna"] - destino["columna"]);
            }
            else
            {
                costo = Math.Sqrt(Math.Pow(destino["fila"] - origen["fila"], 2) + Math.Pow(destino["columna"] - origen["columna"], 2));
            }
            costo = Math.Round(costo * 100) / 100;
            return costo;
        }
        private void dibujar_arbol(TreeNode nodos)
        {
            var vista_de_arbol = new Arbol();
            nodos.ExpandAll();
            vista_de_arbol.Width = 1000;
            vista_de_arbol.Height = 700;
            vista_de_arbol.est_arbol.Nodes.Add(nodos);
            vista_de_arbol.Show();
        }
        private void busqueda_profundidad_recursiva()
        {
            var coordenada_inicial = new Dictionary<string, int>(tablero.coordenadas_inicio);
            var arbol = new TreeNode() { BackColor = Color.CornflowerBlue };
            var visitadas = new List<Dictionary<string, int>>();
            var ruta = new List<Dictionary<string, int>>();
            var meta = false;

            visitadas.Add(coordenada_inicial);
            arbol.Text = coordenadas_a_texto(coordenada_inicial);
            arbol.Text += " Visita: 1 - Inicial";
            ruta.Add(coordenada_inicial);

            desenmascarar_adyacentes(coordenada_inicial["fila"], coordenada_inicial["columna"]);
            var hijos = expandir_hijos_profundidad(coordenada_inicial, visitadas);

            visitadas.AddRange(hijos);
            var pila = new Stack<Dictionary<string, int>>(hijos);
            while (pila.Count() > 0)
            {
                var hijo = pila.Pop();
                meta = buscar_en_nodo(hijo, arbol, visitadas, ruta);
                if (meta)
                {
                    break;
                }
            }
            while (pila.Count() > 0)
            {
                arbol.Nodes.Add(new TreeNode(coordenadas_a_texto(pila.Pop())) { BackColor = Color.Gray });
            }

            if (meta)
            {
                pintar_rectangulos_mapa(ruta);
                dibujar_arbol(arbol);
            }
            else
            {
                Utilidades.mensaje_de_error("No existe ninguna ruta");
                reiniciar_laberinto();
            }
        }
        private void coste_uniforme()
        {
            var arbol = new TreeNode() { BackColor = Color.CornflowerBlue };
            var visitados = new List<TreeNode>();
            var por_visitar = new List<TreeNode>();
            TreeNode nodo_actual = null;
            TreeNode nodo_final = null;
            var coordenada_inicial = tablero.coordenadas_inicio;
            arbol.Text = coordenadas_a_texto_simple(coordenada_inicial);
            arbol.Text += string.Format(" g(n): {0}", 0);
            arbol.Text += " Visita: 1 - Inicial";
            var coordenada_raiz = new Dictionary<string, decimal>();
            coordenada_raiz.Add("fila", coordenada_inicial["fila"]);
            coordenada_raiz.Add("columna", coordenada_inicial["columna"]);
            arbol.Tag = coordenada_raiz;

            visitados.Add(arbol);
            desenmascarar_adyacentes(coordenada_inicial["fila"], coordenada_inicial["columna"]);
            
            var hijos = expandir_hijos_coste_uniforme(coordenada_raiz, visitados, por_visitar);
            foreach (var coordenadas_hijo in hijos)
            {
                var nodo_hijo = new TreeNode(coordenadas_a_texto_simple(coordenadas_hijo)) { BackColor = Color.Gray };
                var datos = new Dictionary<string, decimal>();
                datos.Add("fila", coordenadas_hijo["fila"]);
                datos.Add("columna", coordenadas_hijo["columna"]);
                var tipo = tablero.casillaPorCoordenadas(coordenadas_hijo["fila"], coordenadas_hijo["columna"]).tipo;
                var costo = personajes[personaje_seleccionado].costos[tipo];
                datos.Add("acumulado", costo);
                nodo_hijo.Text += string.Format(" g(n): {0}", costo);
                nodo_hijo.Tag = datos;
                arbol.Nodes.Add(nodo_hijo);
                insertar_en_orden_coste_uniforme(nodo_hijo, por_visitar);
            }

            while (por_visitar.Count > 0)
            {
                nodo_actual = por_visitar.First();
                por_visitar.Remove(nodo_actual);
                var coordenadas = nodo_actual.Tag as Dictionary<string, decimal>;

                nodo_actual.Text += " Visita: " + visita.ToString();

                var coordenadas_int = new Dictionary<string, int>();
                coordenadas_int.Add("fila",(int)coordenadas["fila"]);
                coordenadas_int.Add("columna", (int)coordenadas["columna"]);
                realizar_movimiento(coordenadas_int);
                if (verificar_victoria())
                {
                    nodo_actual.BackColor = Color.Gold;
                    nodo_final = nodo_actual;
                    break;
                }
                else
                {
                    visitados.Add(nodo_actual);
                    nodo_actual.BackColor = Color.White;
                    hijos = expandir_hijos_coste_uniforme(coordenadas, visitados, por_visitar);
                    foreach (var coordenadas_hijo in hijos)
                    {
                        var nodo_hijo = new TreeNode(coordenadas_a_texto_simple(coordenadas_hijo)) { BackColor = Color.Gray };
                        var datos = new Dictionary<string, decimal>();
                        datos.Add("fila", coordenadas_hijo["fila"]);
                        datos.Add("columna", coordenadas_hijo["columna"]);
                        var tipo = tablero.casillaPorCoordenadas(coordenadas_hijo["fila"], coordenadas_hijo["columna"]).tipo;
                        var costo = personajes[personaje_seleccionado].costos[tipo];
                        var datos_padre = nodo_actual.Tag as Dictionary<string, decimal>;
                        datos.Add("acumulado", costo + datos_padre["acumulado"]);
                        nodo_hijo.Text += string.Format(" g(n): {0}", datos["acumulado"]);
                        nodo_hijo.Tag = datos;
                        nodo_actual.Nodes.Add(nodo_hijo);
                        insertar_en_orden_coste_uniforme(nodo_hijo, por_visitar);
                  
                    }
                    tabla.Refresh();
                    System.Threading.Thread.Sleep(200);
                }
            }
            if (nodo_final != null)
            {
                pintar_rectangulos_mapa(generar_ruta_aE(nodo_final));
                dibujar_arbol(arbol);
            }
            else
            {
                Utilidades.mensaje_de_error("No existe ninguna ruta");
                reiniciar_laberinto();
            }
        }
        private void voraz_primero_el_mejor()
        {
            var arbol = new TreeNode() { BackColor = Color.CornflowerBlue };
            var visitados = new List<TreeNode>();
            var por_visitar = new List<TreeNode>();
            TreeNode nodo_actual = null;
            TreeNode nodo_final = null;
            var coordenada_inicial = tablero.coordenadas_inicio;
            arbol.Text = coordenadas_a_texto_VPM(coordenada_inicial);
            arbol.Text += " Visita: 1 - Inicial";
            arbol.Tag = coordenada_inicial;

            visitados.Add(arbol);
            desenmascarar_adyacentes(coordenada_inicial["fila"], coordenada_inicial["columna"]);
            var hijos = expandir_hijos_VPM(coordenada_inicial, visitados, por_visitar);
            foreach (var coordenadas_hijo in hijos)
            {
                var nodo_hijo = new TreeNode(coordenadas_a_texto_VPM(coordenadas_hijo)) { BackColor = Color.Gray };
                nodo_hijo.Tag = coordenadas_hijo;
                arbol.Nodes.Add(nodo_hijo);
                insertar_en_orden_VPM(nodo_hijo, por_visitar);
            }

            while (por_visitar.Count > 0)
            {
                nodo_actual = por_visitar.First();
                por_visitar.Remove(nodo_actual);
                var coordenadas = nodo_actual.Tag as Dictionary<string, int>;

                nodo_actual.Text += " Visita: " + visita.ToString();

                realizar_movimiento(coordenadas);
                if (verificar_victoria())
                {
                    nodo_actual.BackColor = Color.Gold;
                    nodo_final = nodo_actual;
                    break;
                }
                else
                {
                    visitados.Add(nodo_actual);
                    nodo_actual.BackColor = Color.White;
                    hijos = expandir_hijos_VPM(coordenadas, visitados, por_visitar);
                    foreach(var coordenadas_hijo in hijos)
                    {
                        var nodo_hijo = new TreeNode(coordenadas_a_texto_VPM(coordenadas_hijo)) { BackColor = Color.Gray };
                        nodo_hijo.Tag = coordenadas_hijo;
                        nodo_actual.Nodes.Add(nodo_hijo);
                        insertar_en_orden_VPM(nodo_hijo, por_visitar);
                    }
                    tabla.Refresh();
                    System.Threading.Thread.Sleep(200);
                }
            }
            if (nodo_final != null)
            {
                pintar_rectangulos_mapa(generar_ruta(nodo_final));
                dibujar_arbol(arbol);
            }
            else
            {
                Utilidades.mensaje_de_error("No existe ninguna ruta");
                reiniciar_laberinto();
            }
        }
        private void a_estrella()
        {
            var arbol = new TreeNode() { BackColor = Color.CornflowerBlue };
            var visitados = new List<TreeNode>();
            var por_visitar = new List<TreeNode>();
            TreeNode nodo_actual = null;
            TreeNode nodo_final = null;
            var coordenada_inicial = tablero.coordenadas_inicio;
            var distancia_inicial = calcular_distancia(coordenada_inicial, tablero.coordenadas_fin);
            arbol.Text = coordenadas_a_texto_simple(coordenada_inicial);
            arbol.Text += string.Format(" g(n): {0}  h(n): {1}  f(n): {2}", 0, distancia_inicial, distancia_inicial);
            arbol.Text += " Visita: 1 - Inicial";
            var coordenada_raiz = new Dictionary<string, decimal>();
            coordenada_raiz.Add("fila", coordenada_inicial["fila"]);
            coordenada_raiz.Add("columna", coordenada_inicial["columna"]);

            arbol.Tag = coordenada_raiz;

            visitados.Add(arbol);
            desenmascarar_adyacentes(coordenada_inicial["fila"], coordenada_inicial["columna"]);
            var hijos = expandir_hijos_coste_uniforme(coordenada_raiz, visitados, por_visitar);
            foreach (var coordenadas_hijo in hijos)
            {
                var nodo_hijo = new TreeNode(coordenadas_a_texto_simple(coordenadas_hijo)) { BackColor = Color.Gray };
                var datos = new Dictionary<string, decimal>();
                datos.Add("fila", coordenadas_hijo["fila"]);
                datos.Add("columna", coordenadas_hijo["columna"]);
                var tipo = tablero.casillaPorCoordenadas(coordenadas_hijo["fila"], coordenadas_hijo["columna"]).tipo;
                var costo = personajes[personaje_seleccionado].costos[tipo];
                datos.Add("acumulado", costo);
                nodo_hijo.Tag = datos;
                var distancia_hijo = calcular_distancia(coordenadas_hijo, tablero.coordenadas_fin);
                nodo_hijo.Text += string.Format(" g(n): {0}  h(n): {1}  f(n): {2}", costo, distancia_hijo, (decimal)distancia_hijo + costo);
                arbol.Nodes.Add(nodo_hijo);
                insertar_en_orden_a_est(nodo_hijo, por_visitar);
            }

            while (por_visitar.Count > 0)
            {
                nodo_actual = por_visitar.First();
                por_visitar.Remove(nodo_actual);
                var coordenadas = nodo_actual.Tag as Dictionary<string, decimal>;

                nodo_actual.Text += " Visita: " + visita.ToString();

                var coordenadas_int = new Dictionary<string, int>();
                coordenadas_int.Add("fila", (int)coordenadas["fila"]);
                coordenadas_int.Add("columna", (int)coordenadas["columna"]);
                realizar_movimiento(coordenadas_int);
                if (verificar_victoria())
                {
                    nodo_actual.BackColor = Color.Gold;
                    nodo_final = nodo_actual;
                    break;
                }
                else
                {
                    visitados.Add(nodo_actual);
                    nodo_actual.BackColor = Color.White;
                    hijos = expandir_hijos_coste_uniforme(coordenadas, visitados, por_visitar);
                    foreach (var coordenadas_hijo in hijos)
                    {
                        var nodo_hijo = new TreeNode(coordenadas_a_texto_simple(coordenadas_hijo)) { BackColor = Color.Gray };
                        var datos = new Dictionary<string, decimal>();
                        datos.Add("fila", coordenadas_hijo["fila"]);
                        datos.Add("columna", coordenadas_hijo["columna"]);
                        var tipo = tablero.casillaPorCoordenadas(coordenadas_hijo["fila"], coordenadas_hijo["columna"]).tipo;
                        var costo = personajes[personaje_seleccionado].costos[tipo];
                        var datos_padre = nodo_actual.Tag as Dictionary<string, decimal>;
                        datos.Add("acumulado", costo + datos_padre["acumulado"]);
                        var distancia = calcular_distancia(coordenadas_hijo, tablero.coordenadas_fin);
                        nodo_hijo.Text += string.Format(" g(n): {0}  h(n): {1}  f(n): {2}", datos["acumulado"], distancia, (decimal)distancia + datos["acumulado"]);
                        nodo_hijo.Tag = datos;
                        nodo_actual.Nodes.Add(nodo_hijo);
                        insertar_en_orden_a_est(nodo_hijo, por_visitar);

                    }
                    tabla.Refresh();
                    System.Threading.Thread.Sleep(200);
                }
            }
            if (nodo_final != null)
            {
                pintar_rectangulos_mapa(generar_ruta_aE(nodo_final));
                dibujar_arbol(arbol);
            }
            else
            {
                Utilidades.mensaje_de_error("No existe ninguna ruta");
                reiniciar_laberinto();
            }
        }
        private List<Dictionary<string, int>> generar_ruta(TreeNode nodo_final)
        {
            var ruta = new List<Dictionary<string, int>>();
            var nodo = nodo_final;

            while(nodo.Parent != null)
            {
                nodo.BackColor = Color.YellowGreen;
                ruta.Add(nodo.Tag as Dictionary<string, int>);
                nodo = nodo.Parent;
            }
            nodo_final.BackColor = Color.Gold;
            ruta.Add(nodo.Tag as Dictionary<string, int>);
            return ruta;
        }
        private List<Dictionary<string, int>> generar_ruta_aE(TreeNode nodo_final)
        {
            var ruta = new List<Dictionary<string, int>>();
            var nodo = nodo_final;
            Dictionary<string, decimal> aux;
            Dictionary<string, int> aux_2;
            while (nodo.Parent != null)
            {
                nodo.BackColor = Color.YellowGreen;
                aux = nodo.Tag as Dictionary<string, decimal>;
                aux_2 = new Dictionary<string, int>();
                aux_2["fila"] = (int)aux["fila"];
                aux_2["columna"] = (int)aux["columna"];
                ruta.Add(aux_2);
                nodo = nodo.Parent;
            }
            aux = nodo.Tag as Dictionary<string, decimal>;
            aux_2 = new Dictionary<string, int>();
            aux_2["fila"] = (int)aux["fila"];
            aux_2["columna"] = (int)aux["columna"];
            ruta.Add(aux_2);
            nodo_final.BackColor = Color.Gold;
            return ruta;
        }
        private void insertar_en_orden_coste_uniforme(TreeNode hijo, List<TreeNode> por_visitar)
        {
            int posicion = 0;
            bool es_mejor = true;
            TreeNode reemplazar = null;
            var acumulado = (hijo.Tag as Dictionary<string, decimal>)["acumulado"];

            foreach (var nodo in por_visitar)
            {
                if (acumulado < (nodo.Tag as Dictionary<string, decimal>)["acumulado"])
                {
                    break;
                }
                posicion++;
            }

            var datos_hijo = hijo.Tag as Dictionary<string, decimal>;
            foreach (var nodo in por_visitar)
            {
                var datos = nodo.Tag as Dictionary<string, decimal>;

                if (datos_hijo["fila"] == datos["fila"] && datos_hijo["columna"] == datos["columna"])
                {
                    if (datos_hijo["acumulado"] < datos["acumulado"])
                    {
                        reemplazar = nodo;
                        break;
                    }
                    else
                    {
                        es_mejor = false;
                        break;
                    }
                    
                }
                
            }
            if (es_mejor)
            {
                por_visitar.Insert(posicion, hijo);
                if(reemplazar != null)
                {
                    por_visitar.Remove(reemplazar);
                    reemplazar.Parent.Nodes.Remove(reemplazar);
                }
            }
            else
            {
                hijo.Remove();
            }

        }
        private void insertar_en_orden_a_est(TreeNode hijo, List<TreeNode> por_visitar)
        {
            int posicion = 0;
            bool es_mejor = true;
            TreeNode reemplazar = null;
            var dict = hijo.Tag as Dictionary<string, decimal>;
            var aux = new Dictionary<string, int>();
            aux["fila"] = (int)dict["fila"];
            aux["columna"] = (int)dict["columna"];

            var costo = dict["acumulado"];
            var distancia = (decimal)calcular_distancia(aux, tablero.coordenadas_fin);
            decimal valor = costo + distancia;

            foreach (var nodo in por_visitar)
            {
                aux["fila"] = (int)(nodo.Tag as Dictionary<string, decimal>)["fila"];
                aux["columna"] = (int)(nodo.Tag as Dictionary<string, decimal>)["columna"];
                var costo_nodo = (nodo.Tag as Dictionary<string, decimal>)["acumulado"];
                var distancia_nodo = (decimal)calcular_distancia(aux, tablero.coordenadas_fin);
                var valor_nodo = costo_nodo + distancia_nodo;
                if (valor < valor_nodo)
                {
                    break;
                }
                posicion++;
            }

            foreach (var nodo in por_visitar)
            {
                var datos = nodo.Tag as Dictionary<string, decimal>;

                if (dict["fila"] == datos["fila"] && dict["columna"] == datos["columna"])
                {
                    if (dict["acumulado"] < datos["acumulado"])
                    {
                        reemplazar = nodo;
                        break;
                    }
                    else
                    {
                        es_mejor = false;
                        break;
                    }

                }

            }
            if (es_mejor)
            {
                por_visitar.Insert(posicion, hijo);
                if (reemplazar != null)
                {
                    por_visitar.Remove(reemplazar);
                }
            }
            else
            {
                hijo.Remove();
            }

        }
        private void insertar_en_orden_VPM(TreeNode hijo, List<TreeNode> por_visitar)
        {
            var distancia_a_meta = calcular_distancia(hijo.Tag as Dictionary<string, int>, tablero.coordenadas_fin);
            int posicion = 0;
            foreach(var nodo in por_visitar)
            {
                if(distancia_a_meta < calcular_distancia(nodo.Tag as Dictionary<string, int>, tablero.coordenadas_fin))
                {
                    break;
                }
                posicion++;
            }
            por_visitar.Insert(posicion, hijo);
        }
        private void pintar_rectangulos_mapa(List<Dictionary<string, int>> ruta)
        {
            foreach (var coordenada in ruta)
            {
                var casilla = tabla.GetControlFromPosition(coordenada["columna"] + 1, coordenada["fila"] + 1);
                var datos = casilla.Tag as Dictionary<string, string>;
                datos.Add("ruta", "");
            }
            tabla.Refresh();
        }
        private string coordenadas_a_texto(Dictionary<string, int> coordenadas)
        {
            var tipo = tablero.casillaPorCoordenadas(coordenadas["fila"], coordenadas["columna"]).tipo;
            var costo = personajes[personaje_seleccionado].costos[tipo];
            var texto = string.Format("({0}, {1}) Costo: {2}", char.ConvertFromUtf32(65 + coordenadas["columna"]), coordenadas["fila"] + 1, costo);
            return texto;
        }
        private string coordenadas_a_texto_VPM(Dictionary<string, int> coordenadas)
        {
            var costo = calcular_distancia(coordenadas, tablero.coordenadas_fin);
            var texto = string.Format("({0}, {1}) h(n): {2}", char.ConvertFromUtf32(65 + coordenadas["columna"]), coordenadas["fila"] + 1, costo);
            return texto;
        }
        private string coordenadas_a_texto_simple(Dictionary<string, int> coordenadas)
        {
            var texto = string.Format("({0}, {1})", char.ConvertFromUtf32(65 + coordenadas["columna"]), coordenadas["fila"] + 1);
            return texto;
        }
        bool buscar_en_nodo(Dictionary<string, int> coordenadas, TreeNode arbol, List<Dictionary<string, int>> coordenadas_ya_enlistadas, List<Dictionary<string, int>> ruta)
        {
            var meta = false;
            realizar_movimiento(coordenadas);
            tabla.Refresh();
            System.Threading.Thread.Sleep(200);
            var texto = string.Format("{0} Visita: {1}", coordenadas_a_texto(coordenadas), visita - 1);
            var rama = new TreeNode(texto);

            if (verificar_victoria())
            {
                rama.Text += " - Meta";
                ruta.Add(coordenadas);
                rama.BackColor = Color.Gold;
                meta = true;
            }
            else
            {
                var hijos = expandir_hijos_profundidad(coordenadas, coordenadas_ya_enlistadas);

                coordenadas_ya_enlistadas.AddRange(hijos);
                var pila = new Stack<Dictionary<string, int>>(hijos);
                while (pila.Count() > 0)
                {
                    var hijo = pila.Pop();
                    meta = buscar_en_nodo(hijo, rama, coordenadas_ya_enlistadas, ruta);
                    if (meta)
                    {
                        ruta.Add(coordenadas);
                        rama.BackColor = Color.YellowGreen;
                        break;
                    }
                }
                while (pila.Count() > 0)
                {
                    rama.Nodes.Add(new TreeNode(coordenadas_a_texto(pila.Pop())) { BackColor = Color.Gray });
                }
            }
            arbol.Nodes.Add(rama);
            return meta;
        }
        private List<Dictionary<string, int>> expandir_hijos_profundidad(Dictionary<string, int> coordenadas_inicio, List<Dictionary<string, int>> coordenadas_visitadas)
        {
            string[] lista_de_prioridad = config_prioridad.lista_de_prioridades();
            var hijos = new List<Dictionary<string, int>>();

            foreach(string direccion in lista_de_prioridad)
            {
                var coordenadas_hijo = new Dictionary<string, int>();
                coordenadas_hijo["fila"] = coordenadas_inicio["fila"];
                coordenadas_hijo["columna"] = coordenadas_inicio["columna"];
                
                switch (direccion)
                {
                    case "Arriba":        
                        coordenadas_hijo["fila"]--;
                        break;
                    case "Derecha":
                        coordenadas_hijo["columna"]++;
                        break;
                    case "Abajo":
                        coordenadas_hijo["fila"]++;
                        break;
                    case "Izquierda":
                        coordenadas_hijo["columna"]--;
                        break;
                    default:
                        break;
                }

                if (es_coordenada_valida(coordenadas_hijo) && es_habitable(coordenadas_hijo))
                {
                    var ya_fue_visitada = false;
                    
                    foreach(var visitada in coordenadas_visitadas)
                    {
                        if (visitada["fila"] == coordenadas_hijo["fila"] && visitada["columna"] == coordenadas_hijo["columna"]) ya_fue_visitada = true;
                    }

                    if(!ya_fue_visitada) hijos.Add(coordenadas_hijo);
                }
            }
            return hijos;
        }
        private List<Dictionary<string, int>> expandir_hijos_coste_uniforme(Dictionary<string, decimal> coordenadas_inicio, List<TreeNode> visitadas, List<TreeNode> por_visitar)
        {
            string[] lista_de_prioridad = config_prioridad.lista_de_prioridades();
            var hijos = new List<Dictionary<string, int>>();

            foreach (string direccion in lista_de_prioridad)
            {
                var coordenadas_hijo = new Dictionary<string, int>();
                coordenadas_hijo["fila"] = (int)coordenadas_inicio["fila"];
                coordenadas_hijo["columna"] = (int)coordenadas_inicio["columna"];

                switch (direccion)
                {
                    case "Arriba":
                        coordenadas_hijo["fila"]--;
                        break;
                    case "Derecha":
                        coordenadas_hijo["columna"]++;
                        break;
                    case "Abajo":
                        coordenadas_hijo["fila"]++;
                        break;
                    case "Izquierda":
                        coordenadas_hijo["columna"]--;
                        break;
                    default:
                        break;
                }

                if (es_coordenada_valida(coordenadas_hijo) && es_habitable(coordenadas_hijo))
                {
                    var ya_fue_visitada = false;
                    
                    foreach (var visitada in visitadas)
                    {
                        var coordenadas_visitadas = visitada.Tag as Dictionary<string, decimal>;
                        if ((int)coordenadas_visitadas["fila"] == coordenadas_hijo["fila"] && (int)coordenadas_visitadas["columna"] == coordenadas_hijo["columna"])
                        {
                            ya_fue_visitada = true;
                            break;
                        }

                    }

                    if (!ya_fue_visitada)
                    {
                        hijos.Add(coordenadas_hijo);
                    }
                }
            }
            return hijos;
        }
        private List<Dictionary<string, int>> expandir_hijos_VPM(Dictionary<string, int> coordenadas_inicio, List<TreeNode> visitadas, List<TreeNode> por_visitar)
        {
            string[] lista_de_prioridad = config_prioridad.lista_de_prioridades();
            var hijos = new List<Dictionary<string, int>>();

            foreach (string direccion in lista_de_prioridad)
            {
                var coordenadas_hijo = new Dictionary<string, int>();
                coordenadas_hijo["fila"] = coordenadas_inicio["fila"];
                coordenadas_hijo["columna"] = coordenadas_inicio["columna"];

                switch (direccion)
                {
                    case "Arriba":
                        coordenadas_hijo["fila"]--;
                        break;
                    case "Derecha":
                        coordenadas_hijo["columna"]++;
                        break;
                    case "Abajo":
                        coordenadas_hijo["fila"]++;
                        break;
                    case "Izquierda":
                        coordenadas_hijo["columna"]--;
                        break;
                    default:
                        break;
                }

                if (es_coordenada_valida(coordenadas_hijo) && es_habitable(coordenadas_hijo))
                {
                    var ya_fue_visitada = false;
                    var ya_fue_agregada = false;

                    foreach (var visitada in visitadas)
                    {
                        var coordenadas_visitadas = visitada.Tag as Dictionary<string, int>;
                        if (coordenadas_visitadas["fila"] == coordenadas_hijo["fila"] && coordenadas_visitadas["columna"] == coordenadas_hijo["columna"])
                        {
                            ya_fue_visitada = true;
                            break;
                        }

                    }

                    if (!ya_fue_visitada)
                    {
                        foreach(var coordenada in por_visitar)
                        {
                            var coordenadas_visitadas = coordenada.Tag as Dictionary<string, int>;
                            if (coordenadas_visitadas["fila"] == coordenadas_hijo["fila"] && coordenadas_visitadas["columna"] == coordenadas_hijo["columna"])
                            {
                                ya_fue_agregada = true;
                                break;
                            }
                        }
                        if(!ya_fue_agregada) hijos.Add(coordenadas_hijo);
                    }
                }
            }
            return hijos;
        }
        private bool actualizar_costos()
        {
            for(int i = 1; i <= tablero.texturas_asignadas.Count(); i++)
            {
                var label_textura = tabla_costos.GetControlFromPosition(0, i) as Label;
                var costo = tabla_costos.GetControlFromPosition(1, i) as TextBox;
                if (costo.Text == "")
                {
                    Utilidades.mensaje_de_error("Falta un costo");
                    return false;
                }
                personajes[personaje_seleccionado].costos[label_textura.Tag as string] = decimal.Parse(costo.Text);
            }
            return true;
        }
        private void bloquear_controles()
        {
            var controles = new List<Control>();
            controles.Add(comboBox_Algoritmo_Busqueda);
            controles.Add(comboBox1);
            controles.Add(comboColumnaD);
            controles.Add(comboColumnaO);
            controles.Add(comboFilaO);
            controles.Add(comboFilaD);
            //controles.Add(boton_reiniciar);
            controles.Add(button1);
            controles.Add(button3);
            controles.Add(radioButton_Euclidiana);
            controles.Add(radioButton_Manhattan);
            controles.Add(tabla_costos);
            foreach (var c in controles)
            {
                c.Enabled = false;
            }
            /*var combos = panel1.Controls.OfType<ComboBox>();
            foreach (ComboBox c in combos)
            {
                c.SelectedIndex = -1;
            }*/
        }
        private void desbloquear_controles()
        {
            var controles = new List<Control>();
            controles.Add(comboBox_Algoritmo_Busqueda);
            controles.Add(comboBox1);
            controles.Add(comboColumnaD);
            controles.Add(comboColumnaO);
            controles.Add(comboFilaO);
            controles.Add(comboFilaD);
            //controles.Add(boton_reiniciar);
            controles.Add(button1);
            controles.Add(button3);
            controles.Add(radioButton_Euclidiana);
            controles.Add(radioButton_Manhattan);
            controles.Add(tabla_costos);
            foreach (var c in controles)
            {
                c.Enabled = true;
            }
        }
        private void dibujar_laberinto()
        {
            Dictionary<string, string> datos;
            Textura t;
            var cant_filas = tablero.dimensiones["filas"];
            var cant_columnas = tablero.dimensiones["columnas"];
            ToolTip info;
            var tam_casillas = 45;

            if(tabla != null)
            {
                tabla.Dispose();
            }

            tabla = new Tabla_laberinto(tablero.texturas_asignadas)
            {
                Visible = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            tabla.ColumnStyles.Clear();
            tabla.RowStyles.Clear();
            tabla.Controls.Clear();
            tabla.RowCount = cant_filas + 1;
            tabla.ColumnCount = cant_columnas + 1;
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25));
            tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
            tabla.Controls.Add(new Label() { Text = "/", Dock = DockStyle.Fill}, 0, 0);
            for (int i = 1; i <= cant_columnas; i++)
            {
                tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, tam_casillas));
                tabla.Controls.Add(new Label() { Text = char.ConvertFromUtf32(64 + i) , Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.Transparent }, i, 0);
            }
            for (int i = 1; i <= cant_filas; i++)
            {
                tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, tam_casillas));
                tabla.Controls.Add(new Label() { Text = i.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.Transparent }, 0, i);
                for (int j = 1; j <= cant_columnas; j++)
                {
                    datos = new Dictionary<string, string>();
                    t = tablero.texturaPorCoordenadas(i - 1, j - 1);
                    datos.Add("textura", t.nombre);
                    datos.Add("visible", "1");
                    var tipo = tablero.casillaPorCoordenadas(i - 1, j - 1).tipo;
                    var casilla = new Label() { Text = "", BackColor = Color.Transparent,  Tag = datos, TextAlign = ContentAlignment.TopLeft, Dock = DockStyle.Fill };
                    info = new ToolTip();
                    info.SetToolTip(casilla, string.Format("Codigo: {0}, Textura: {1}", tipo, t.nombre));
                    tabla.Controls.Add(casilla, j, i);
                }
            }
            contenedor_laberinto.Controls.Add(tabla);
            tabla.Visible = true;
        }
        private void enmascarar_todo()
        {
            for(int i = 1; i <= tablero.dimensiones["filas"]; i++)
            {
                for(int j = 1; j <= tablero.dimensiones["columnas"]; j++)
                {
                    var datos = (tabla.GetControlFromPosition(j, i).Tag) as Dictionary<string, string>;
                    datos["visible"] = "0";
                }
            }
            tabla.Update();
        }
        private void desenmascarar_todo()
        {
            for (int i = 1; i <= tablero.dimensiones["filas"]; i++)
            {
                for (int j = 1; j <= tablero.dimensiones["columnas"]; j++)
                {
                    var datos = (tabla.GetControlFromPosition(j, i).Tag) as Dictionary<string, string>;
                    datos["visible"] = "1";
                }
            }
            tabla.Update();
        }
        private void agregar_personajes_al_combo()
        {
            var combo = comboBox1;
            combo.Items.Clear();
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.DrawMode = DrawMode.OwnerDrawFixed;
            combo.ItemHeight = 32;
            combo.SelectionChangeCommitted += new System.EventHandler(combo_personajes_seleccionado);
            combo.DrawItem += new DrawItemEventHandler(dibujar_items_combo_personajes);
            List<string> nombres = new List<string>();
            foreach(var p in personajes)
            {
                nombres.Add(p.nombre);
            }
            combo.Items.AddRange(nombres.ToArray());
        }
        private void combo_personajes_seleccionado(object sender, EventArgs e)
        {
            personaje_seleccionado = (sender as ComboBox).SelectedIndex;
            poner_costos_en_tabla();
            habilitar_combos();
        }
        private void poner_costos_en_tabla()
        {
            quitar_costos_anteriores();
            var costos = personajes[personaje_seleccionado].costos;
            var header = tabla_costos.RowStyles[0];
            foreach(KeyValuePair<string, decimal> costo in costos)
            {
                tabla_costos.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                tabla_costos.RowCount++;
                var nombre_textura = new Label()
                {
                    Text = tablero.texturas_asignadas[costo.Key].nombre,
                    Tag = costo.Key,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                var costo_textura = new TextBox()
                { 
                    Text = costo.Value.ToString(),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0)
                };
                costo_textura.KeyDown += new KeyEventHandler(costos_KeyDown);
                costo_textura.KeyPress += new KeyPressEventHandler(costos_KeyPress);
                costo_textura.TextChanged += new EventHandler(cambio_texto);
                tabla_costos.Controls.Add(nombre_textura, 0, tabla_costos.RowCount - 1);
                tabla_costos.Controls.Add(costo_textura, 1, tabla_costos.RowCount - 1);
            }
        }
        private void cambio_texto(object sender, EventArgs e)
        {

        }
        private void quitar_costos_anteriores()
        {
            var cantidad = tabla_costos.RowCount;
            for(int i = cantidad - 1; i > 0; i--)
            {
                tabla_costos.GetControlFromPosition(0, i).Dispose();
                tabla_costos.GetControlFromPosition(1, i).Dispose();
                tabla_costos.RowStyles.RemoveAt(i);
            }
            tabla_costos.RowCount = 1;
        }
        private void habilitar_combos()
        {
            var combos = panel1.Controls.OfType<ComboBox>();
            foreach(var combo in combos)
            {
                combo.Enabled = true;
            }
        }
        private void dibujar_items_combo_personajes(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
            {
                var opcion = (sender as ComboBox).Items[e.Index];
                var nombre_de_avatar = opcion as string;
                if (e.Index < personajes.Length)
                {
                    var miniatura = personajes[e.Index].imagen;
                    e.Graphics.DrawImage(miniatura, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
                e.Graphics.DrawString(nombre_de_avatar, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + 32, e.Bounds.Top);
            }
        }
        private void agregar_opciones_a_combos_coordenadas()
        {
            List<string> opciones = new List<string>();
            for(int i = 0; i < tablero.dimensiones["filas"]; i++)
            {
                opciones.Add((i + 1).ToString()); 
            }
            comboFilaO.Items.Clear();
            comboFilaO.Items.AddRange(opciones.ToArray());
            comboFilaD.Items.Clear();
            comboFilaD.Items.AddRange(opciones.ToArray());
            opciones.Clear();
            for (int i = 0; i < tablero.dimensiones["columnas"]; i++)
            {
                opciones.Add(char.ConvertFromUtf32(65 + i));
            }
            comboColumnaO.Items.Clear();
            comboColumnaO.Items.AddRange(opciones.ToArray());
            comboColumnaD.Items.Clear();
            comboColumnaD.Items.AddRange(opciones.ToArray());
        }
        private void dibujar_personaje(int fila, int columna)
        {
            var personaje = personajes[personaje_seleccionado];
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            casilla.Image = personaje.imagen;
            desenmascarar_adyacentes(fila, columna);
            casilla.Text += " "+visita.ToString();
            visita++;
        }
        private void desenmascarar_adyacentes(int fila, int columna)
        {
            modificar_enmascaramiento(fila, columna, true);
            modificar_enmascaramiento(fila + 1, columna, true);
            modificar_enmascaramiento(fila - 1, columna, true);
            modificar_enmascaramiento(fila, columna + 1, true);
            modificar_enmascaramiento(fila, columna - 1, true);
        }
        private void enmascarar_adyacentes(int fila, int columna)
        {
            modificar_enmascaramiento(fila, columna, false);
            modificar_enmascaramiento(fila + 1, columna, false);
            modificar_enmascaramiento(fila - 1, columna, false);
            modificar_enmascaramiento(fila, columna + 1, false);
            modificar_enmascaramiento(fila, columna - 1, false);
        }
        private void modificar_enmascaramiento(int fila, int columna, bool v)
        {
            var coordenada = new Dictionary<string, int>();
            coordenada.Add("fila", fila);
            coordenada.Add("columna", columna);
            if (es_coordenada_valida(coordenada))
            {
                var datos = (tabla.GetControlFromPosition(columna + 1, fila + 1).Tag) as Dictionary<string, string>;
                if (v)
                {
                    datos["visible"] = "1";
                }
                else
                {
                    datos["visible"] = "0";
                }
            }
        }
        private void dibujar_inicio(int fila, int columna)
        {
            var d = new Dictionary<string, int>();
            d.Add("fila", fila);
            d.Add("columna", columna);
            if (!es_habitable(d))
            {
                Utilidades.mensaje_de_error("El personaje no puede estar en esta casilla");
                comboFilaO.SelectedIndex = -1;
                comboColumnaO.SelectedIndex = -1;
                return;
            }
            var personaje = personajes[comboBox1.SelectedIndex];
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            casilla.Image = personaje.imagen;
            desenmascarar_adyacentes(fila, columna);
            casilla.Text = "Inicio, 1";
        }
        private void comboFilaO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = comboFilaO;
            var columna = comboColumnaO;
            if(columna.Text != "" && columna.SelectedIndex != -1 && fila.SelectedIndex != -1)
            {
                if (hay_personaje_dibujado()) borrar_inicio();
                dibujar_inicio(fila.SelectedIndex, columna.SelectedIndex);
                tablero.coordenadas_inicio["fila"] = fila.SelectedIndex;
                tablero.coordenadas_inicio["columna"] = columna.SelectedIndex;
                tablero.coordenadas_personaje["fila"] = fila.SelectedIndex;
                tablero.coordenadas_personaje["columna"] = columna.SelectedIndex;
                if (hay_meta_dibujada() && hay_personaje_dibujado())
                {
                    button1.Enabled = true;
                }
            }
        }
        private void comboColumnaO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = comboFilaO;
            var columna = comboColumnaO;
            if (fila.Text != "" && columna.SelectedIndex != -1 && fila.SelectedIndex != -1)
            {
                if (hay_personaje_dibujado()) borrar_inicio();
                dibujar_inicio(fila.SelectedIndex, columna.SelectedIndex);
                tablero.coordenadas_inicio["fila"] = fila.SelectedIndex;
                tablero.coordenadas_inicio["columna"] = columna.SelectedIndex;
                tablero.coordenadas_personaje["fila"] = fila.SelectedIndex;
                tablero.coordenadas_personaje["columna"] = columna.SelectedIndex;
                if (hay_meta_dibujada() && hay_personaje_dibujado())
                {
                    button1.Enabled = true;
                }
            }
        }
        private void borrar_personaje(int fila, int columna)
        {
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            casilla.Image = null;
        }
        private void borrar_inicio()
        {
            var fila = tablero.coordenadas_personaje["fila"];
            var columna = tablero.coordenadas_personaje["columna"];
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            casilla.Image = null;
            casilla.Text = "";
        }
        private bool hay_personaje_dibujado()
        {
            return (tablero.coordenadas_personaje["fila"] != -1 && tablero.coordenadas_personaje["columna"] != -1);
        }
        private void comboFilaD_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = comboFilaD;
            var columna = comboColumnaD;
            if (columna.Text != "" && columna.SelectedIndex != -1 && fila.SelectedIndex != -1)
            {
                if (hay_meta_dibujada()) borrar_meta();
                dibujar_meta(fila.SelectedIndex, columna.SelectedIndex);
                tablero.coordenadas_fin["fila"] = fila.SelectedIndex;
                tablero.coordenadas_fin["columna"] = columna.SelectedIndex;
                tablero.coordenadas_personaje["fila"] = tablero.coordenadas_inicio["fila"];
                tablero.coordenadas_personaje["columna"] = tablero.coordenadas_inicio["columna"];
                if (hay_meta_dibujada() && hay_personaje_dibujado())
                {
                    button1.Enabled = true;
                }
            }
        }
        private void comboColumnaD_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = comboFilaD;
            var columna = comboColumnaD;
            if (fila.Text != "" && columna.SelectedIndex != -1 && fila.SelectedIndex != -1)
            {
                if (hay_meta_dibujada()) borrar_meta();
                dibujar_meta(fila.SelectedIndex, columna.SelectedIndex);
                tablero.coordenadas_fin["fila"] = fila.SelectedIndex;
                tablero.coordenadas_fin["columna"] = columna.SelectedIndex;
                tablero.coordenadas_personaje["fila"] = tablero.coordenadas_inicio["fila"];
                tablero.coordenadas_personaje["columna"] = tablero.coordenadas_inicio["columna"];
                if (hay_meta_dibujada() && hay_personaje_dibujado())
                {
                    button1.Enabled = true;
                }
            }
        }
        private void dibujar_meta(int fila, int columna)
        {
            var d = new Dictionary<string, int>();
            d.Add("fila", fila);
            d.Add("columna", columna);
            if (!es_habitable(d))
            {
                Utilidades.mensaje_de_error("El personaje no puede estar en esta casilla");
                comboFilaD.SelectedIndex = -1;
                comboColumnaD.SelectedIndex = -1;
                return;
            }
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            var datos = casilla.Tag as Dictionary<string, string>;
            datos["visible"] = "1";
            casilla.Image = imagen_meta;
            tabla.Update();
        }
        private void borrar_meta()
        {
            var fila = tablero.coordenadas_fin["fila"];
            var columna = tablero.coordenadas_fin["columna"];
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            casilla.Image = null;
            tabla.Update();
        }
        private bool hay_meta_dibujada()
        {
            bool resultado;
            resultado = (tablero.coordenadas_fin["fila"] != -1 && tablero.coordenadas_fin["columna"] != -1);
            return resultado;
        }
        private void mover_personaje(Dictionary<string, int> coordenada_nueva)
        {
            tablero.coordenadas_personaje["fila"] = coordenada_nueva["fila"];
            tablero.coordenadas_personaje["columna"] = coordenada_nueva["columna"];
            dibujar_personaje(tablero.coordenadas_personaje["fila"], tablero.coordenadas_personaje["columna"]);
        } 
        private bool verificar_victoria()
        {
            if(tablero.coordenadas_personaje["fila"] == tablero.coordenadas_fin["fila"] && tablero.coordenadas_personaje["columna"] == tablero.coordenadas_fin["columna"])
            {
                MessageBox.Show("Victoria!");
                boton_reiniciar.Enabled = true;

                return true;
            }
            return false;
        }
        private bool es_habitable(Dictionary<string, int> coordenada_nueva)
        {
            var casilla = tablero.casillaPorCoordenadas(coordenada_nueva["fila"],coordenada_nueva["columna"]);
            if (personajes[personaje_seleccionado].costos[casilla.tipo] == -1) return false;
            return true;
        }
        private bool es_coordenada_valida(Dictionary<string, int> coordenada_nueva)
        {
            if (coordenada_nueva["fila"] >= tablero.dimensiones["filas"]) return false;
            if (coordenada_nueva["fila"] < 0) return false;
            if (coordenada_nueva["columna"] >= tablero.dimensiones["columnas"]) return false;
            if (coordenada_nueva["columna"] < 0) return false;
            return true;
        }
        private void mapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciar_configuracion();
        }
        private void reiniciar_laberinto()
        {
            tabla.SuspendLayout();
            Label casilla;
            borrar_meta();
            for(int i = 1; i <= tablero.dimensiones["filas"]; i++)
            {
                for(int j = 1; j <= tablero.dimensiones["columnas"]; j++)
                {
                    casilla = tabla.GetControlFromPosition(j, i) as Label;
                    var datos = casilla.Tag as Dictionary<string, string>;
                    datos["visible"] = "0";
                    if (datos.ContainsKey("ruta"))
                        datos.Remove("ruta");
                    if (casilla == null || casilla.Text == "") continue;
                    casilla.Text = "";
                }
            }
            tabla.ResumeLayout();
        }
        private void Formulario_Juego_KeyDown(object sender, KeyEventArgs e)
        {
            if (juego_iniciado && modo_manual)
            {
                var coordenada = Calcular_coordenada(e.KeyCode);

                if(coordenada != null)
                {
                    if (!es_coordenada_valida(coordenada) || !es_habitable(coordenada))
                    {
                        System.Media.SystemSounds.Asterisk.Play();
                        e.Handled = true;
                        return;
                    }

                    realizar_movimiento(coordenada);
                    verificar_victoria();
                }
            }
            e.Handled = true;
        }
        private void realizar_movimiento(Dictionary<string, int> coordenada)
        {
            borrar_personaje(tablero.coordenadas_personaje["fila"], tablero.coordenadas_personaje["columna"]);
            mover_personaje(coordenada);
        }
        private Dictionary<string,int> Calcular_coordenada(Keys tecla)
        {
            var coordenada = new Dictionary<string,int>();
            coordenada.Add("fila", tablero.coordenadas_personaje["fila"]);
            coordenada.Add("columna", tablero.coordenadas_personaje["columna"]);

            if(tecla == Keys.Up)
            {
                coordenada["fila"] --;
            }
            else if(tecla == Keys.Right)
            {
                coordenada["columna"] ++;
            }
            else if(tecla == Keys.Down)
            {
                coordenada["fila"] ++;
            }
            else if(tecla == Keys.Left)
            {
                coordenada["columna"] --;
            }
            else 
            {
                coordenada = null;
            }

            return coordenada;
        }
        private void costos_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string texto = (sender as TextBox).Text;
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Decimal && e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.OemMinus)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                if (texto == "" || texto.Contains("."))
                {
                    nonNumberEntered = true;
                }
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                if (texto != "")
                {
                    nonNumberEntered = true;
                }
            }
            else if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
            if (texto.Contains("-") && e.KeyCode != Keys.Back)
            {
                if(e.KeyCode != Keys.D1 && e.KeyCode != Keys.Oem1)
                {
                    nonNumberEntered = true;
                }
            }
            if (texto.Contains('.') && texto.IndexOf('.') == texto.Length - 3 && e.KeyCode != Keys.Back)
            {
                nonNumberEntered = true;
            }
        }
        private void costos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }
        private void button_reiniciar_Click(object sender, EventArgs e)
        {
            reiniciar_laberinto();
            tablero.coordenadas_personaje["fila"] = tablero.coordenadas_inicio["fila"];
            tablero.coordenadas_personaje["columna"] = tablero.coordenadas_inicio["columna"];
            if (hay_meta_dibujada())
            {
                dibujar_meta(tablero.coordenadas_fin["fila"], tablero.coordenadas_fin["columna"]);
            }
            if(hay_personaje_dibujado())
            {
                dibujar_inicio(tablero.coordenadas_inicio["fila"], tablero.coordenadas_inicio["columna"]);
            }
            desbloquear_controles();
            desenmascarar_todo();
        }
        private void boton_guardar_costos_click(object sender, EventArgs e)
        {
            actualizar_costos();
        }
        private void prioridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            config_prioridad.ShowDialog();
        }

        private void poner_prioridades()
        {
            var prioridades = config_prioridad.lista_de_prioridades();

            pictureBox1.ImageLocation = "Prioridad/" + prioridades[0] + ".png";
            pictureBox1.Refresh();
            pictureBox2.ImageLocation = "Prioridad/" + prioridades[1] + ".png";
            pictureBox2.Refresh();
            pictureBox3.ImageLocation = "Prioridad/" + prioridades[2] + ".png";
            pictureBox3.Refresh();
            pictureBox4.ImageLocation = "Prioridad/" + prioridades[3] + ".png";
            pictureBox4.Refresh();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (hay_personaje_dibujado())
            {
                var personaje = personajes[personaje_seleccionado];
                var casilla = tabla.GetControlFromPosition(tablero.coordenadas_inicio["columna"] + 1, tablero.coordenadas_inicio["fila"] + 1) as Label;
                casilla.Image = personaje.imagen;
            }
        }
    }
}
