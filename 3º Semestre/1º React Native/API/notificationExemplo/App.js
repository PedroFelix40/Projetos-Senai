import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';

// import do audio
import audiozap from "./assets/shooting-sound-fx-159024.wav"

// 1º importar os recursos do expo notification
import * as Notifications from "expo-notifications";

// 2º pedir permissão ao usuário para notificar
Notifications.requestPermissionsAsync();

// 4º Definir como asnotificações devem ser tratadas qnd recebidas
Notifications.setNotificationHandler({
  handleNotification: async () => ({
    //Mostar alerta quando a notificação for recebida
    shouldShowAlert: true,

    // Reproduz som ao receber notificação
    shouldPlaySound: true,

    // Número de notificações no icone do app
    shouldSetBadge: false
  })
})

export default function App() {

  // Função para lidar com chamada de notificação 
  const handleCallNotifications = async () => {
    // Obtém status das permissões
    const { status } = await Notifications.getPermissionsAsync();

    // Verifica se o usuário concedeu permissão
    if (status !== "granted") {
      alert("Você não deixou as notificações ativas")
      return;
    }

    // Ageda uma notficação
    await Notifications.scheduleNotificationAsync({
      content: {
        title: "Bem vindo ao Senai",
        body: "Notificação recebida.",
        sound: [audiozap]
      },
      trigger: null
    })
  }

  return (
    <View style={styles.container}>
      <TouchableOpacity style={styles.button} onPress={handleCallNotifications}>
        <Text style={styles.text}>Clique</Text>
      </TouchableOpacity>
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
  button: {
    width: "80%",
    height: 50,
    backgroundColor: "red",
    alignItems: "center",
    justifyContent: "center",
    borderRadius: 10
  },
  text: {
    color : "#fff",
    fontWeight: "bold"
  }
});
