
# Analisis de Algoritmos - Busqueda Lineal

## 1. Descripcion

Este proyecto implementa el algoritmo de busqueda lineal
utilizando el lenguaje de programacion C#.

El objetivo es analizar experimentalmente el comportamiento
del algoritmo mediante la medicion de tiempos de ejecucion
para diferentes tamanos de entrada.

## 2. Objetivo

Comprobar experimentalmente el crecimiento del tiempo de
ejecucion de un algoritmo de complejidad lineal O(n).

## 3. Metodologia

Se realizan pruebas con tres tamanos de entrada:

- n
- 4n
- 16n

Antes de las mediciones se aplica un proceso de calentamiento
(Warm-up).

Para cada tamano se realizan cinco corridas y se calcula
el tiempo promedio.

Finalmente se calculan los siguientes ratios:

- T(4n) / T(n)
- T(16n) / T(4n)
- T(16n) / T(n)

## 4. Algoritmo utilizado

Busqueda lineal.

En cada prueba se busca un elemento que no existe en el
arreglo, obligando al algoritmo a recorrer todos sus elementos.

## 5. Complejidad algoritmica

Complejidad temporal en el peor caso: O(n).

## 6. Tecnologias

- Lenguaje: C#
- Plataforma: .NET
- Editor: Visual Studio Code
- Control de versiones: Git
- Repositorio: GitHub

## 7. Ejecucion

Para ejecutar el proyecto:

```bash
dotnet run
```

## 8. Resultados

Los resultados experimentales se obtienen al ejecutar
el programa. Los tiempos y ratios pueden variar segun
el equipo utilizado.
