import { StatusBar } from 'expo-status-bar';
import { useEffect, useState } from 'react';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';

export default function App() {

  // Hook state
  const [count, setCount] = useState(0)

  // função para incrementar

  const increment = () => {
    setCount(count + 1)
  }
  const decremento = () => {
    if (count > 0) {
      setCount(count - 1)
    }
  }

  useEffect(() => {
    console.warn(`Contador atualizado: ${count}`)
  }, [count])

  return (
    <View style={styles.container}>
      <View style={styles.box}>
        <Text style={styles.text} >Contador: {count}</Text>

        <View style={styles.button}>
          <TouchableOpacity
            onPress={increment}
            style={styles.button1}
          >
            <Text style={styles.text} >Incrementar</Text>
          </TouchableOpacity>
          <TouchableOpacity
            onPress={decremento}
            style={styles.button2}
          >
            <Text style={styles.text} >Decrementar</Text>
          </TouchableOpacity>
        </View>
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
    justifyContent: 'center',
  },
  box: {
    width: '80%',
    height: 180,
    backgroundColor: '#c1c1c1',
    alignItems: 'center',
    justifyContent: 'space-around',
    borderRadius: 5,
  },
  button: {
    flexDirection: 'row',
    gap: 10,
  },
  button1: {
    backgroundColor: 'green',
  },
  button2: {
    backgroundColor: 'purple'
  },
  text: {
    fontSize: 20,
  }
});
