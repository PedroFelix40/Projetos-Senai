import { StatusBar } from 'expo-status-bar';
import { SafeAreaView } from 'react-native';
import Person from './src/components/Person/Person';



export default function App() {
  return (
    <SafeAreaView>

      <Person name='Pedro' age={19} />

      <StatusBar style="auto" />
    </SafeAreaView>
  );
}

