# Se requiere la instalación de los paquetes

# Carga de paquetes

library(tidyverse)
library(caret)
library(neuralnet)

# Carga de datos
datos = iris

# Separacion en grupo de entrenamiento y pruebas

muestra = createDataPartition(datos$Species, p = 0.8, list = F)
View(muestra)

train = datos[muestra,]
test = datos[-muestra,]
head(train, 5)
tail(train, 4)
train[6:10,]
sepal_length = train$Sepal.Length
hist(sepal_length)


red.neuronal = neuralnet(Species ~ Sepal.Length + Sepal.Width + Petal.Length + Petal.Width, data=train, hidden=c(2,3))
red.neuronal$act.fct

plot(red.neuronal)

prediccion = predict(red.neuronal, test, type='class')
View(prediccion)
plot(red.neuronal)

prediccion = predict(red.neuronal, test, typr='class')
decodificarCol = apply(prediccion, 1, which.max)
codificado = data.frame(decodificarCol)
codificado = mutate(codificado, especie=recode(codificado$decodificarCol, "1"= "Setosa", "2"="Versicolor", "3"= "Virginica"))
test$Especie.Pred = codificado$especie
