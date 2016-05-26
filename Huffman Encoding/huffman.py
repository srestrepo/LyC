# Compresor Huffman
# Creado por: Sergio Restrepo
# Requiere Python 3

import queue, sys

class HuffmanNode():
    # Define un nodo que puede tener un simbolo asociado e hijos izquierdo y derecho
    def __init__(self, left=None, right=None, symbol=None):
        self.left = left
        self.right = right
        self.symbol = symbol
    def __lt__(self, other):
        return self.symbol;
    def __eq__(self, other):
        return self.symbol

# Creamos el arbol de simbolos utilizando una cola de prioridad
def encode(symbolFrequency):
    symbolqueue = queue.PriorityQueue()

    # Convertimos todos los simbolos en nodos y los agregamos a la cola
    for k,v in symbolFrequency.items():
        node = HuffmanNode(symbol = k)
        symbolqueue.put((v,node))
        
    # Sacamos dos nodos de la cola y creamos un nodo nuevo con dos hijos y la nueva prioridad
    while symbolqueue.qsize() > 1:
        low = symbolqueue.get()
        high = symbolqueue.get()
        node = HuffmanNode(low[1], high[1])
        symbolqueue.put((low[0]+high[0], node))
        
    return symbolqueue.get()

# Revisamos los parametros

if len(sys.argv) < 2:
    print("Cantidad de argumentos incorrecta.")
    print("Uso: huffman.py archivo.txt")
    sys.exit(1);

# Creamos un diccionario vacio para almacenar los simbolos y sus codigos
symbolDictionary = {}

# Recorremos el arbol recordando el prefijo para cada uno de los nodos
def treewalk(node, prefix = ''):
    if not node.symbol is None:
        # Si el nodo es final entonces lo agregamos al diccionario
        global symbolDictionary
        symbolDictionary[node.symbol] = prefix
    else:
        # Si el nodo es interno, recorremos sus hijos
        treewalk(node.left, prefix + '0')
        treewalk(node.right, prefix + '1')

# Leemos el texto 
with open (sys.argv[1], "r") as myfile:
    text = myfile.read()

# Creamos la lista de simbolos y sus frecuencias
symbolFrequency = {}
for symbol in text:
    if(symbol in symbolFrequency):
        symbolFrequency[symbol] += 1
    else:
        symbolFrequency[symbol] = 1

# Creamos el arbol
huff = encode(symbolFrequency)
root = huff[1]

# Recorremos el arbol para crear el diccionario de simbolos
treewalk(root)

# Codigo para imprimir la tabla de simbolos
#for k,v in symbolDictionary.items():
#    print("%s\t%s" % (k,v))

# Recorremos el texto e imprimimos los codigos huffman para cada simbolo
for symbol in text:
    print(symbolDictionary[symbol], end = "")

sys.exit(0)
