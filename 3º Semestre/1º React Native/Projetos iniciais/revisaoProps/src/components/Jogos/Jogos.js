import { StyleSheet, Text, View } from "react-native";


const Jogos = ({ nameGame, descricao, preco }) => {
    return (
        <View style={styles.container}>
            <Text style={styles.text}> Nome: {nameGame} </Text>
            <Text style={styles.text}> Descrição: {descricao} </Text>
            <Text style={styles.text}> Preço: {preco} </Text>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        width: 300,
        backgroundColor: '#c1c1c1',
        padding: 10,
        margin: 10,
        borderRadius: 5,
    },
    text: {
        color: 'black',
        fontFamily: 'Poppins_300Light',
        fontSize: 15,
    }
});

export default Jogos;