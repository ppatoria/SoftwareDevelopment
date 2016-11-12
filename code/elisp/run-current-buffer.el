(defun xah-run-current-file ()
  "Execute the current file.
For example, if the current buffer is the file x.py, then it'll call 「python x.py」 in a shell.
The file can be Emacs Lisp, PHP, Perl, Python, Ruby, JavaScript, Bash, Ocaml, Visual Basic, TeX, Java, Clojure.
File suffix is used to determine what program to run.

If the file is modified or not saved, save it automatically before run.

URL `http://ergoemacs.org/emacs/elisp_run_current_file.html'
version 2016-01-28"
  (interactive)
  (let (
	(suffix-map
	 ;; (‹extension› . ‹shell program name›)
	 '(
	   ("php" . "php")
	   ("pl" . "perl")
	   ("py" . "python")
	   ("py3" . ,(if (string-equal system-type "windows-nt") "c:/Python32/python.exe" "python3"))
	   ("rb" . "ruby")
	   ("go" . "go run")
	   ("js" . "node") ; node.js
	   ("sh" . "bash")
	   ("clj" . "java -cp /home/xah/apps/clojure-1.6.0/clojure-1.6.0.jar clojure.main")
	   ("rkt" . "racket")
	   ("ml" . "ocaml")
	   ("vbs" . "cscript")
	   ("tex" . "pdflatex")
	   ("latex" . "pdflatex")
	   ("java" . "javac")
	   ;; ("pov" . "/usr/local/bin/povray +R2 +A0.1 +J1.2 +Am2 +Q9 +H480 +W640")
	   )
	 )

	fname
	fSuffix
	prog-name
	cmd-str)

    (when (null (buffer-file-name)) (save-buffer))
    (when (buffer-modified-p) (save-buffer))

    (setq fname (buffer-file-name))
    (setq fSuffix (file-name-extension fname))
    (setq prog-name (cdr (assoc fSuffix suffix-map)))
    (setq cmd-str (concat prog-name " \""   fname "\""))

    (cond
     ((string-equal fSuffix "el") (message "elisp") (load fname))
     ((string-equal fSuffix "java")
      (progn
	(message "java")
	(shell-command cmd-str "*xah-run-current-file output*" )
	(shell-command
	 (format "java %s" (file-name-sans-extension (file-name-nondirectory fname))))))
     (t (if prog-name
	    (progn
	     (message "Running… %s as %s" fname cmd-str )
	      (shell-command cmd-str "*xah-run-current-file output*" ))
	  (message "No recognized program file suffix for this file."))))))
