#!/usr/bin/python
import socket
HOST = '192.0.2.20'              # Endereco IP do Servidor
PORT = 33301                       # Porta que o Servidor esta
tcp = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
origem = (HOST, PORT)
tcp.bind(origem)
tcp.listen(1)
while True:
    con, cliente = tcp.accept()
    print 'Conectado :', cliente
    resposta_body = '<html><body>%s</body></html>' % (socket.gethostname())
    resposta_headers = {
        'Content-Type': 'text/html; enconding=utf8',
        'Content-Length': len(resposta_body),
        'Connection': 'Close',    
    }
    resposta_headers_raw = ''.join('%s: %s\n'% (k, v) for k, v in resposta_headers.iteritems())
    resposta_proto = 'HTTP/1.1'
    resposta_status = '200'
    resposta_status_text = 'Ok'


    con.send('%s %s %s' % (resposta_proto, resposta_status, resposta_status_text))
    con.send('\n')
    con.send(resposta_headers_raw)
    con.send('\n')
    con.send(resposta_body)
    print 'Finalizando sessão de :', cliente
    con.close()