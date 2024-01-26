import React, { useState } from 'react';
import { StatusBar } from 'expo-status-bar';
import { Image, StyleSheet, Text, TextInput, TouchableOpacity, View } from 'react-native';

export default function App() {
  const [contador, setContador] = useState(0);
  const incremento = () => setContador(prevCount => prevCount + 1);
  const decremento = () => setContador(prevCount => prevCount - 1);
  return (
    <View style={styles.container}>


      {/* Imagem */}
      <Image
        style={styles.imagem}
        source={{
          uri: 'https://reactnative.dev/img/tiny_logo.png',
        }}
      />
      <Text style={styles.text}>
        Primeiro projeto utilizando React Native
      </Text>



      <TextInput
        style={styles.input}
        placeholder='Digite sua opinião:'
      />

      <TouchableOpacity style={styles.button} onPress={incremento}>
        <Text > Clique aqui para ganhar mil reais</Text>
      </TouchableOpacity>

      <TouchableOpacity style={styles.button} onPress={decremento}>
        <Text > Clique aqui para perder dinheiro</Text>
      </TouchableOpacity>
      
      <View style={styles.countContainer}>
        <Text>Número de otários: {contador}</Text>
      </View>

      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center'
  },
  text: {
    fontSize: 20
  },
  input: {
    width: '90%',
    height: 40,
    borderWidth: 1,
    paddingLeft: 7,
    marginTop: 10
  },
  imagem: {
    width: '20%',
    height: 70,
    borderRadius: 50
  },
  button: {
    width: '90%',
    height: 40,

    marginTop: 30,
    alignItems: 'center',
    backgroundColor: 'gray',
    padding: 10,
    borderRadius: 5,
    borderWidth: 1,
  },
  countContainer: {
    alignItems: 'center',
    padding: 10,
  },
});
