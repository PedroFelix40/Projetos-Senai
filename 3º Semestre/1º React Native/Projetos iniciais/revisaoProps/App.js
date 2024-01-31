import { StatusBar } from 'expo-status-bar';
import { FlatList, SafeAreaView } from 'react-native';

// Import dos componentes
import Person from './src/components/Person/Person';
import Jogos from './src/components/Jogos/Jogos';

// Import da font
import { useFonts, Poppins_300Light, } from '@expo-google-fonts/poppins';
import { SingleDay_400Regular } from '@expo-google-fonts/single-day';

export default function App() {

  let [fontsLoaded, fontError] = useFonts({
    Poppins_300Light,
    SingleDay_400Regular,
  });

  if (!fontsLoaded && !fontError) {
    return null;
  }

  const peopleList = [
    { id: "1", name: "Pedro", age: 30 },
    { id: "2", name: "Pedro", age: 30 },
    { id: "3", name: "Pedro", age: 30 }
  ]

  const jogosList = [
    { id: "1", nameGame: "GTA", descricao: "Jogo de mundo aberto", preco: "150,00" },
    { id: "2", nameGame: "FIFA", descricao: "jogo superfaturado", preco: "400,00" },
    { id: "3", nameGame: "Cabeça de xicara", descricao: "Jogo de xicaras com cabeça", preco: "100,00" },
    //{ id: "4", nameGame: "lets GO", descricao: "Jogo de tiro", preco: "50,00" }
  ]

  return (
    <SafeAreaView>

      {/* Flatlist */}
      <FlatList
        data={peopleList}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) => <Person name={item.name} age={item.age} />}
      />

      <FlatList
        data={jogosList}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) =>
          <Jogos
            nameGame={item.nameGame}
            descricao={item.descricao}
            preco={item.preco}
          />}
      />
     {/* <Jogos nameGame= "lets GO" descricao= "Jogo de tiro" preco= "50,00"/> */}

      {/* <Person name='Pedro' age={19} />
      <Person name='Mumu' age={18} />
      <Person name='Garbelini' age={18} /> */}

      <StatusBar style="auto" />
    </SafeAreaView>
  );
}

